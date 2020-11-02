using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.ML;
using AzureMLNET.Shared;
using AzureMLNET.Shared.Schemas;

namespace AzureMLNET.Shared
{
    public class AzureMLModelLoader : IModelLoader<AzureMLONNX.Input, AzureMLONNX.Output>
    {
        private MLContext _mlContext = new MLContext();
        
        public ITransformer GetPipeline(string modelPath = null)
        {
            if(modelPath == null)
            {
                throw new NotImplementedException("No pipeline defined");
            }

            var inputColumns = new string[]
            {
                "vendor_id", "rate_code", "passenger_count", "trip_time_in_secs", "trip_distance", "payment_type"
            };

            var outputColumns = new string[] { "variable_out1" };

            var onnxPredictionPipeline =
                _mlContext
                    .Transforms
                    .ApplyOnnxModel(
                        outputColumnNames: outputColumns,
                        inputColumnNames: inputColumns,
                        modelPath);

            var emptyDv = _mlContext.Data.LoadFromEnumerable(new AzureMLONNX.Input[] { });

            return onnxPredictionPipeline.Fit(emptyDv);
        }

        public void SavePipeline(ITransformer pipeline, string savePath)
        {
            _mlContext.Model.Save(pipeline, null, savePath);
        }

        public ITransformer GetSavedModel(string modelName)
        {
            var assembly = typeof(AzureMLNET.Shared.AzureMLModelLoader).Assembly;
            Stream model = assembly.GetManifestResourceStream($"AzureMLNET.Shared.MLModels.{modelName}.zip");
            return _mlContext.Model.Load(model, out var schema);
        }

        public PredictionEngine<AzureMLONNX.Input, AzureMLONNX.Output> GetPredictionEngine(ITransformer model)
        {
            return _mlContext.Model.CreatePredictionEngine<AzureMLONNX.Input, AzureMLONNX.Output>(model);
        }
    }
}
