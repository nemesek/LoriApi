using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    public static class Translator
    {
        public static string TranslateToSpanish(ISentence sentence, string name)
        {
            if (sentence.SentenceId == Sentences.HaveYouAlreadyDecidedOnAHome)
                return $"Gran {name}. Para empezar, veamos dónde estás actualmente en el proceso. ¿Ya te has decidido por un hogar?";
            if (sentence.SentenceId == Sentences.OkToGetIncomeAndEmploymentInfo)
                return $"No es raro {name}, puedo ayudar a determinar eso. Solo necesito obtener información de verificación de ingresos y empleo. ¿OKAY?";
            if (sentence.SentenceId == Sentences.CanYouProvideW2Informaion)
                return "¿Sería capaz de proporcionar cualquier información W-2 ahora, por ejemplo, en los últimos años? Puedes subir aquí si es así.";
            if (sentence.SentenceId == Sentences.PleaseUploadFiles)
                return "Genial, vamos a subirlo ahora, solo pregúntame si tienes alguna pregunta al respecto ";
            return null;
        }
    }
}
