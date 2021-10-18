using System.Collections.Generic;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Infra.DynamoDb.Models;
using AutoMapper;

namespace ArchAspNetDynamoDb.Infra.DynamoDb.Mappers
{
    public interface IDynamoMapper
    {
        TModel FromDocumentModel<TModel,TDocument>(TDocument document);
        IEnumerable<TModel> FromDocumentModel<TModel,TDocument>(IEnumerable<TDocument> documents);
        TDocument ToDocumentModel<TDocument, TModel>(TModel entity);
        IEnumerable<TDocument> ToDocumentModel<TDocument, TModel>(IEnumerable<TModel> entities);
    }

    public class DynamoMapper : IDynamoMapper
    {
        private readonly IMapper mapper;

        public DynamoMapper(IMapper mapper)
        {
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public TModel FromDocumentModel<TModel, TDocument>(TDocument document) => mapper.Map<TModel>(document);

        public IEnumerable<TModel> FromDocumentModel<TModel, TDocument>(IEnumerable<TDocument> documents) => mapper.Map<IEnumerable<TModel>>(documents);
        public TDocument ToDocumentModel<TDocument, TModel>(TModel entity) => mapper.Map<TDocument>(entity);

        public IEnumerable<TDocument> ToDocumentModel<TDocument, TModel>(IEnumerable<TModel> entities) => mapper.Map<IEnumerable<TDocument>>(entities);
    }
}