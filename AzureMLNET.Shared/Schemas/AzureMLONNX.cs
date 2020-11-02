using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Onnx;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureMLNET.Shared.Schemas
{
    public class AzureMLONNX
    {
        public class Input
        {
            [ColumnName("vendor_id")]
            public string VendorId { get; set; }

            [ColumnName("rate_code"), OnnxMapType(typeof(Int64), typeof(Single))]
            public Int64 RateCode { get; set; }

            [ColumnName("passenger_count"), OnnxMapType(typeof(Int64), typeof(Single))]
            public Int64 PassengerCount { get; set; }

            [ColumnName("trip_time_in_secs"), OnnxMapType(typeof(Int64), typeof(Single))]
            public Int64 TripTimeInSecs { get; set; }

            [ColumnName("trip_distance")]
            public float TripDistance { get; set; }

            [ColumnName("payment_type")]
            public string PaymentType { get; set; }
        }

        public class Output
        {
            [ColumnName("variable_out1")]
            public float[] PredictedFare { get; set; }
        }
    }
}
