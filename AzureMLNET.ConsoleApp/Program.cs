using System;
using Microsoft.ML;
using AzureMLNET.Shared;
using AzureMLNET.Shared.Schemas;

namespace AzureMLNET.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            // Define Azure ML ONNX model path
            var modelPath = "azureml-model.onnx";

            // Initialize Model Loader
            var modelLoader = new AzureMLModelLoader();
            
            // Create ML.NET pipeline with ONNX Model
            var pipeline = modelLoader.GetPipeline(modelPath);

            // Save ML.NET pipeline
            modelLoader.SavePipeline(pipeline, "azureml-mlnet-model.zip");
        }
    }
}
