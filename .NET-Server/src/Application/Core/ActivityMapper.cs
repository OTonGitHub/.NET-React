using Domain;
using Riok.Mapperly.Abstractions;

namespace Application.Core;

[Mapper(
    // PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive,
    // UseDeepCloning = false,
    AllowNullPropertyAssignment = false
)]
public static partial class ActivityMapper
{
    public static partial void UpdateActivity(Activity FromActivity, Activity ToActivity);
}






