using ApiTemplate.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiTemplate.Core.Infrastructure.Repository
{
    public interface IRepositoryService<TKey, T>
        where T : IDomainEntity<TKey>
    {
        #region Public Methods

        /// <summary>
        /// Inserta un registro en base de datos
        /// </summary>
        /// <param name="entity">
        /// Entidad a insertar
        /// </param>
        /// <returns>
        /// Identificador de los registros insertados
        /// </returns>
        TKey Add(T entity);

        /// <summary>
        /// Inserta un conjunto de registros a la bd
        /// </summary>
        /// <param name="entityList">
        /// Listado de registros
        /// </param>
        /// <returns>
        /// Identificador de los registros insertados
        /// </returns>
        IEnumerable<TKey> Add(IEnumerable<T> entityList);

        /// <summary>
        /// Inserta un registro en base de datos
        /// </summary>
        /// <param name="entity">Entidad a insertar
        /// </param>
        /// <returns>
        /// Identificador de los registros insertados
        /// </returns>
        Task<TKey> AddAsync(T entity);

        /// <summary>
        /// Inserta un conjunto de registros a la bd
        /// </summary>
        /// <param name="entityList">
        /// Listado de registros
        /// </param>
        /// <returns>
        /// Identificador de los registros insertados
        /// </returns>
        Task<IEnumerable<TKey>> AddAsync(IEnumerable<T> entityList);

        /// <summary>
        /// Devuleve el número de elementos de la entidad especificada por el tipo
        /// </summary>
        /// <returns>
        /// Número de elementos
        /// </returns>
        int Count();

        /// <summary>
        /// Devuleve el número de elementos de la entidad especificada por el tipo
        /// </summary>
        /// <returns>
        /// Número de elementos
        /// </returns>
        Task<int> CountAsync();

        /// <summary>
        /// Elimina un registro de base de datos
        /// </summary>
        /// <param name="t">
        /// Entidad a eliminar
        /// </param>
        void Delete(T deleted);

        /// <summary>
        /// Elimina un listado de registros de la base de datos
        /// </summary>
        /// <param name="t">
        /// Listado de entidades a eliminar
        /// </param>
        void Delete(IEnumerable<T> deletedList);

        /// <summary>
        /// Determina si existe algún elemento que cumpla la expresión indicada
        /// </summary>
        /// <param name="predicate">
        /// Expresión de búsqueda
        /// </param>
        /// <returns>
        /// True si existe algún elemento. False si no exíste ninguno
        /// </returns>
        bool Exist(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Determina si existe algún elemento que cumpla la expresión indicada
        /// </summary>
        /// <param name="predicate">
        /// Expresión de búsqueda
        /// </param>
        /// <returns>
        /// True si existe algún elemento. False si no exíste ninguno
        /// </returns>
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Devuelve un IEnumerable filtrado, ordenado y paginado.
        /// </summary>
        /// <param name="filter">
        /// Expresión para filtrar
        /// </param>
        /// <param name="orderBy">
        /// Expresión para ordenar
        /// </param>
        /// <param name="includeProperties">
        /// Propiedades de inclusión
        /// </param>
        /// <param name="page">
        /// Número de página
        /// </param>
        /// <param name="pageSize">
        /// Tamaño de la página
        /// </param>
        /// <returns>
        /// </returns>
        IEnumerable<T> Filter(
            out int recordsFiltered,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IQueryable<T>> include = null,
            int? start = null,
            int? pageSize = null);

        /// <summary>
        /// Busca un objeto por la clave primaria
        /// </summary>
        /// <param name="id">
        /// Valor de la clave primaria
        /// </param>
        /// <returns>
        /// Objeto de la entidad especificada en el tipo
        /// </returns>
        T GetById(object id);

        /// <summary>
        /// Busca un objeto por la clave primaria
        /// </summary>
        /// <param name="id">
        /// Valor de la clave primaria
        /// </param>
        /// <returns>
        /// Objeto de la entidad especificada en el tipo
        /// </returns>
        Task<T> GetByIdAsync(object id);

        /// <summary>
        /// Genera una consulta sobre la tabla especificada por el tipo
        /// </summary>
        /// <returns>
        /// IEnumerable del tipo especificado
        /// </returns>
        IQueryable<T> Query(Func<IQueryable<T>, IQueryable<T>> include = null);

        /// <summary> Genera una consulta sobre la tabla especificada por el tipo </summary> <param
        /// name="predicate">Función con el filtro de búsqueda</param> <returns>IEnumerable del tipo especificado<</returns>
        IQueryable<T> Query(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IQueryable<T>> include = null);

        /// <summary>
        /// Actualiza un registro en base de datos
        /// </summary>
        /// <param name="updated">
        /// Entidad a actualizar
        /// </param>
        void Update(T updated);

        /// <summary>
        /// Actualiza un conjunto de registros en base de datos
        /// </summary>
        /// <param name="updatedList">
        /// Listado de registros a actualizar
        /// </param>
        void Update(IEnumerable<T> updatedList);

        #endregion Public Methods
    }
}