namespace Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Core.Interfaces;

    public class UpdateBind
    {
        public void Bind<TEntity, TViewModel>(ICollection<TEntity> entities, IEnumerable<TViewModel> models) where TEntity : IEntity where TViewModel : ViewModels.IEntityViewModel
        {
            var modelIds = models.Select(m => m.Id);
            entities.Where(m => !modelIds.Contains(m.Id)).ToList()
                .ForEach(m => entities.Remove(m));

            foreach (var model in models)
            {
                var entity = entities.SingleOrDefault(m => m.Id == model.Id);

                if (entity != null)
                {
                    Mapper.Map(model, entity);
                }
                else
                {
                    entity = Mapper.Map<TEntity>(model);
                    
                    entities.Add(entity);
                }
            }
        }
    }
}
