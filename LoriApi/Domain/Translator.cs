using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    public static class Translator
    {
        public static string TranslateToSpanish(Sentences sentence)
        {
            if (sentence == Sentences.HaveYouAlreadyDecidedOnAHome)
                return "Para empezar, veamos dónde estás actualmente en el proceso. ¿Ya te has decidido por un hogar?";
            if (sentence == Sentences.OkToGetIncomeAndEmploymentInfo)
                return "No es raro Dan, puedo ayudar a determinar eso. Solo necesito obtener información de verificación de ingresos y empleo. ¿OKAY?";
            if (sentence == Sentences.CanYouProvideW2Informaion)
                return "¿Sería capaz de proporcionar cualquier información W-2 ahora, por ejemplo, en los últimos años? Puedes subir aquí si es así.";
            if (sentence == Sentences.PleaseUploadFiles)
                return "Genial, vamos a subirlo ahora, solo pregúntame si tienes alguna pregunta al respecto ";
            return null;
        }
    }
}
