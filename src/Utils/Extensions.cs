namespace Ai.Hgb.Common.Utils {
  public static class Extensions {
    public static bool IsOneOf<T>(this T @this, params T[] values) {
      return values.Contains(@this);
    }
  }
}
