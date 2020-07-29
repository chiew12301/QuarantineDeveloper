using UnityEditor;
using UnityEngine;

/*  How to use
 
    1. Import this script into your unity asset folder
    2. Create a new Game Object
    3. Rename the Game Object you created to the following colors available, add "---" and name ur label
            a. red
            b. cyan
            c. blue
            d. black
            e. green
            f. white
            g. cyan
            h. magenta
            i. yellow
            j. grey

    Example: red---WorldLevel, black---Managers, blue---Players
*/


namespace Leemeoyi
{
    [InitializeOnLoad]
    public class HierarchyLabel : MonoBehaviour
    {
        static HierarchyLabel()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj != null && obj.name.StartsWith("black---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.black);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("black---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("red---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.red);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("red---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("white---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.white);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("white---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("blue---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.blue);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("blue---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("green---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.green);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("green---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("cyan---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.cyan);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("cyan---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("grey---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.grey);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("grey---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("magenta---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.magenta);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("magenta---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("yellow---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.yellow);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("yellow---", "").ToString());
            }
            else if (obj != null && obj.name.StartsWith("white---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, Color.white);
                EditorGUI.DropShadowLabel(selectionRect, obj.name.Replace("white---", "").ToString());
            }
        }
    }
}
