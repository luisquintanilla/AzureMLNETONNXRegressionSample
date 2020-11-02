# Azure ML ONNX Regression ML.NET Sample

Regression model to predict taxi fares trained using Azure Machine Learning Automated ML (AutoML). Azure ML model is exported to ONNX format and is consumed inside a .NET Core 3.1 WPF desktop application.

![Azure ML.NET ONNX WPF Desktop Application](https://user-images.githubusercontent.com/46974588/97821831-cbc55c00-1c81-11eb-8940-a2833180a08c.png)

## Prerequisites

- .NET Core 3.1 SDK
- Visual Studio or Visual Studio Code

## Project Structure

- AzureMLNET.Shared: .NET Standard 2.1 Class Library with helper classes to create, save, and load ML.NET pipeline. 
- AzureMLNET.ConsoleApp: C# .NET Core Console application to create ML.NET prediction pipeline using the Azure Machine Learning ONNX model.
- AzureMLNET.WPF: .NET Core WPF desktop application that takes in user input and uses the ML.NET pipeline to predict taxi fares with the Azure Machine Learning ONNX Model.