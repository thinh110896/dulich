namespace Tourism.Domain.Helpers;

public static class MapperHelper
{
    /// <summary>
    /// Tạo entity từ request model
    /// </summary>
    public static T CreateEntity<T>(object createModel) where T : new()
    {
        var entity = new T();
        MapProperties(entity, createModel);
        return entity;
    }

    /// <summary>
    /// Cập nhật entity từ request model
    /// </summary>
    public static void UpdateEntity<T>(T entity, object updateModel)
    {
        MapProperties(entity, updateModel);
    }

    public static TModel MapToModel<TModel>(object entity) where TModel : new()
    {
        var model = new TModel();
        MapProperties(model, entity);
        return model;
    }

    /// <summary>
    /// Map dữ liệu từ model sang entity
    /// </summary>
    public static void MapProperties<T>(T entity, object model)
    {
        var entityProps = typeof(T).GetProperties().ToDictionary(p => p.Name, p => p);
        var modelProps = model.GetType().GetProperties();

        foreach (var modelProp in modelProps)
        {
            if (!entityProps.TryGetValue(modelProp.Name, out var entityProp) || !entityProp.CanWrite) continue;

            var value = modelProp.GetValue(model);
            if (value != null)
            {
                entityProp.SetValue(entity, value);
            }
        }
    }

}