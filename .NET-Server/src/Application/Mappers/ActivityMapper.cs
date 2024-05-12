using Domain;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers;

[Mapper(
    PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive,
    UseDeepCloning = true
)]
public partial class ActivityMapper
{
    public partial Activity MapActivity(Activity activity);
}






