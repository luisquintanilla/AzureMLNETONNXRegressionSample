using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;

namespace AzureMLNET.Shared
{
    public interface IModelLoader<TIn,TOut> 
        where TIn:class
        where TOut : class,new()
    {
        ITransformer GetPipeline(string modelPath = null);
        void SavePipeline(ITransformer pipeline, string savePath);
        ITransformer GetSavedModel(string modelPath);
        PredictionEngine<TIn, TOut> GetPredictionEngine(ITransformer model);
    }
}
