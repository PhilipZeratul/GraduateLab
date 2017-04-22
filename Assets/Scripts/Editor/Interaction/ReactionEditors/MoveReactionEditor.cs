using UnityEditor;

[CustomEditor(typeof(MoveReaction))]
public class MoveReactionEditor : ReactionEditor
{
    private SerializedProperty playerProperty;
    private SerializedProperty interactionLocationProperty;

    private const string moveReactionPropPlayerName = "player";
    private const string moveReactionPropInteractionLocationName = "interactionLocation";

    protected override void Init()
    {
        playerProperty = serializedObject.FindProperty(moveReactionPropPlayerName);
        interactionLocationProperty = serializedObject.FindProperty(moveReactionPropInteractionLocationName);
    }

    protected override void DrawReaction()
    {
        EditorGUILayout.PropertyField(playerProperty);
        EditorGUILayout.PropertyField(interactionLocationProperty);
    }

    protected override string GetFoldoutLabel()
    {
        return "Move Reaction";
    }
}
