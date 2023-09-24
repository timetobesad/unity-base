using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class HierarchlyEdit : EditorWindow
{
    [MenuItem("dev/hierarchly")]
    public static void showHierEditWind()
    {
        HierarchlyEdit hierWind = GetWindow<HierarchlyEdit>();
        hierWind.titleContent = new GUIContent("Hierarchly editor");
    }

    public void CreateGUI()
    {
        VisualElement rootVisual = rootVisualElement;

        Button mainBtn = new Button();
        mainBtn.name = "renameBtn";
        mainBtn.text = "fix title grid items";
        mainBtn.clicked += MainBtn_clicked;


        rootVisual.Add(mainBtn);
    }

    private void MainBtn_clicked()
    {
        Transform[] objs = GameObject.Find("platform").GetComponentsInChildren<Transform>();

        Regex regMatch = new Regex(@"\d-[A-J ] \(\d\)");
        Regex regPattern = new Regex(@"([\dA-J])");

        foreach (Transform obj in objs)
        {
            string name = obj.gameObject.name;

            if (regMatch.IsMatch(name))
            {
                MatchCollection coll = regPattern.Matches(name);
                obj.name = string.Format("{0}-{1}", int.Parse(coll[2].Value) + 1, coll[1].Value);
            }
        }
    }
}