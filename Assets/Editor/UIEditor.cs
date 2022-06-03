using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class UIEditor : EditorWindow
{
[SerializeField] private int m_SelectedIndex = -1;
  private VisualElement m_RightPane;
  public Vector2 vector2;

  [MenuItem("Tools/My Custom Editor")]
  public static void ShowMyEditor()
  {
    // This method is called when the user selects the menu item in the Editor
    EditorWindow wnd = GetWindow<UIEditor>();
    wnd.titleContent = new GUIContent("My Custom Editor");

    // Limit size of the window
    wnd.minSize = new Vector2(450, 200);
    wnd.maxSize = new Vector2(1920, 720);
  }

  public void CreateGUI()
  {
    StyleSheet styleSheet = (StyleSheet) EditorGUIUtility.Load("UIEditorStyle.uss");

    // Get a list of all sprites in the project
    var allObjectGuids = AssetDatabase.FindAssets("t:Sprite");
    var allObjects = new List<Sprite>();
    foreach (var guid in allObjectGuids)
    {
      allObjects.Add(AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(guid)));
    }

    // Create a two-pane view with the left pane being fixed with
    var splitView = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
    
    // Add the panel to the visual tree by adding it as a child to the root element
    rootVisualElement.Add(splitView);
    rootVisualElement.styleSheets.Add(styleSheet);

    // A TwoPaneSplitView always needs exactly two child elements
    var leftPane = new TwoPaneSplitView(0, 180, TwoPaneSplitViewOrientation.Vertical);
    var leftPaneUp = new ListView();
    leftPaneUp.makeItem = () => new Label();
    leftPaneUp.bindItem = (item, index) => { (item as Label).text = allObjects[index].name; };
    leftPaneUp.itemsSource = allObjects;
    leftPane.Add(leftPaneUp);


    var leftPaneDown = new VisualElement();
    
    leftPane.Add(leftPaneDown);

    splitView.Add(leftPane);

    m_RightPane = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
    splitView.Add(m_RightPane);

  

    // React to the user's selection
    leftPaneUp.onSelectionChange += OnSpriteSelectionChange;

    // Restore the selection index from before the hot reload
    leftPaneUp.selectedIndex = m_SelectedIndex;

    // Store the selection index when the selection changes
    leftPaneUp.onSelectionChange += (items) => { m_SelectedIndex = leftPaneUp.selectedIndex; };
  }

  private void OnSpriteSelectionChange(IEnumerable<object> selectedItems)
  {
    // Clear all previous content from the pane
    m_RightPane.Clear();

    // Get the selected sprite
    var selectedSprite = selectedItems.First() as Sprite;
    if (selectedSprite == null)
      return;

    // Add a new Image control and display the sprite
    var spriteImage = new Image();
    spriteImage.scaleMode = ScaleMode.ScaleToFit;
    spriteImage.sprite = selectedSprite;
    spriteImage.AddToClassList("scale-sprite");

    // Add the Image control to the right-hand pane
    m_RightPane.Add(spriteImage);
  }
}