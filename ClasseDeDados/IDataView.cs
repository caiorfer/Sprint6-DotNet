using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ClasseDeDados
{
    public interface IDataView
    {
        var mlContext = new MLContext();
        var dados = mlContext.Data.LoadFromTextFile<Livro>("dados.csv", separatorChar: ';', hasHeader: true);

        var pipeline = mlContext.Transforms.Concatenate("Features", "Avaliacao", "Titulo")
        .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("PredictedLabel", "Features"))
        .Append(mlContext.Transforms.Conversion.MapValueToKey("PredictedLabel"));


    }
}