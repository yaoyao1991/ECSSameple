//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class AppMatcher {

    public static Entitas.IAllOfMatcher<AppEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<AppEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<AppEntity> AllOf(params Entitas.IMatcher<AppEntity>[] matchers) {
          return Entitas.Matcher<AppEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<AppEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<AppEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<AppEntity> AnyOf(params Entitas.IMatcher<AppEntity>[] matchers) {
          return Entitas.Matcher<AppEntity>.AnyOf(matchers);
    }
}