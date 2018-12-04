//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DebugEntity {

    public DebugAssetComponent debugAsset { get { return (DebugAssetComponent)GetComponent(DebugComponentsLookup.DebugAsset); } }
    public bool hasDebugAsset { get { return HasComponent(DebugComponentsLookup.DebugAsset); } }

    public void AddDebugAsset(bool newB, string newMessage) {
        var index = DebugComponentsLookup.DebugAsset;
        var component = (DebugAssetComponent)CreateComponent(index, typeof(DebugAssetComponent));
        component.b = newB;
        component.message = newMessage;
        AddComponent(index, component);
    }

    public void ReplaceDebugAsset(bool newB, string newMessage) {
        var index = DebugComponentsLookup.DebugAsset;
        var component = (DebugAssetComponent)CreateComponent(index, typeof(DebugAssetComponent));
        component.b = newB;
        component.message = newMessage;
        ReplaceComponent(index, component);
    }

    public void RemoveDebugAsset() {
        RemoveComponent(DebugComponentsLookup.DebugAsset);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class DebugMatcher {

    static Entitas.IMatcher<DebugEntity> _matcherDebugAsset;

    public static Entitas.IMatcher<DebugEntity> DebugAsset {
        get {
            if (_matcherDebugAsset == null) {
                var matcher = (Entitas.Matcher<DebugEntity>)Entitas.Matcher<DebugEntity>.AllOf(DebugComponentsLookup.DebugAsset);
                matcher.componentNames = DebugComponentsLookup.componentNames;
                _matcherDebugAsset = matcher;
            }

            return _matcherDebugAsset;
        }
    }
}
