using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interaces
{
    public interface IMapper<TDto, TEntity>
    {
        TDto ToDto(TEntity entity);
        TDto ToDtoWithId(TEntity entity);
        TEntity ToEntity(TDto entity);
        TEntity ToEntityWithId(TDto entityDto);
    }
}
