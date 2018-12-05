//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class AppContext {

    public AppEntity screenEntity { get { return GetGroup(AppMatcher.Screen).GetSingleEntity(); } }
    public ScreenComponent screen { get { return screenEntity.screen; } }
    public bool hasScreen { get { return screenEntity != null; } }

    public AppEntity SetScreen(int newWidth, int newHeight) {
        if (hasScreen) {
            throw new Entitas.EntitasException("Could not set Screen!\n" + this + " already has an entity with ScreenComponent!",
                "You should check if the context already has a screenEntity before setting it or use context.ReplaceScreen().");
        }
        var entity = CreateEntity();
        entity.AddScreen(newWidth, newHeight);
        return entity;
    }

    public void ReplaceScreen(int newWidth, int newHeight) {
        var entity = screenEntity;
        if (entity == null) {
            entity = SetScreen(newWidth, newHeight);
        } else {
            entity.ReplaceScreen(newWidth, newHeight);
        }
    }

    public void RemoveScreen() {
        screenEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class AppEntity {

    public ScreenComponent screen { get { return (ScreenComponent)GetComponent(AppComponentsLookup.Screen); } }
    public bool hasScreen { get { return HasComponent(AppComponentsLookup.Screen); } }

    public void AddScreen(int newWidth, int newHeight) {
        var index = AppComponentsLookup.Screen;
        var component = (ScreenComponent)CreateComponent(index, typeof(ScreenComponent));
        component.width = newWidth;
        component.height = newHeight;
        AddComponent(index, component);
    }

    public void ReplaceScreen(int newWidth, int newHeight) {
        var index = AppComponentsLookup.Screen;
        var component = (ScreenComponent)CreateComponent(index, typeof(ScreenComponent));
        component.width = newWidth;
        component.height = newHeight;
        ReplaceComponent(index, component);
    }

    public void RemoveScreen() {
        RemoveComponent(AppComponentsLookup.Screen);
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
public sealed partial class AppMatcher {

    static Entitas.IMatcher<AppEntity> _matcherScreen;

    public static Entitas.IMatcher<AppEntity> Screen {
        get {
            if (_matcherScreen == null) {
                var matcher = (Entitas.Matcher<AppEntity>)Entitas.Matcher<AppEntity>.AllOf(AppComponentsLookup.Screen);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherScreen = matcher;
            }

            return _matcherScreen;
        }
    }
}