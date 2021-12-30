using generic.app.common.Enums.Exts;

namespace generic.app.common.Enums
{
    /// <summary>
    /// Class GenericEnumerator.
    /// </summary>
    /// <remarks>Priscy Antonio Reales</remarks>
    public class GenericEnumerator
    {
        /// <summary>
        /// Enum DateFormat
        /// </summary>
        public enum DateFormat
        {
            /// <summary>
            /// The dmy
            /// </summary>
            Dmy,
            /// <summary>
            /// The dmyh
            /// </summary>
            Dmyh,
            /// <summary>
            /// The mdy
            /// </summary>
            Mdy,
            /// <summary>
            /// The mdyh
            /// </summary>
            Mdyh,
            /// <summary>
            /// The ymd
            /// </summary>
            Ymd,
            /// <summary>
            /// The ymdh
            /// </summary>
            Ymdh,
            /// <summary>
            /// The HHMMSS
            /// </summary>
            Hhmmss
        }

        /// <summary>
        /// Enum Headers
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Headers
        {
            /// <summary>
            /// The x API key ges con
            /// </summary>
            [EnumeratorExtension("X-API-CODE")]
            XApiKey
        }

        /// <summary>
        /// Enum LogType
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum LogType
        {
            /// <summary>
            /// The information
            /// </summary>
            [EnumeratorExtension("INFO")]
            Info,

            /// <summary>
            /// The error
            /// </summary>
            [EnumeratorExtension("ERROR")]
            Error
        }

        /// <summary>
        /// Enum TypeRequest
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum TypeRequest
        {
            /// <summary>
            /// The request
            /// </summary>
            Request,

            /// <summary>
            /// The respponse
            /// </summary>
            Response,

            /// <summary>
            /// The exception
            /// </summary>
            Exception
        }

        /// <summary>
        /// Enum Separador
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Separator
        {
            /// <summary>
            /// The barra inclinada
            /// </summary>
            [EnumeratorExtension("/")]
            Slash,

            /// <summary>
            /// The guion
            /// </summary>
            [EnumeratorExtension("-")]
            Hyphen,

            /// <summary>
            /// The punto
            /// </summary>
            [EnumeratorExtension(".")]
            Point,

            /// <summary>
            /// The sin separador
            /// </summary>
            [EnumeratorExtension("")]
            Empty,

            /// <summary>
            /// The punto and coma
            /// </summary>
            [EnumeratorExtension(";")]
            Semicolon,

        }
        /// <summary>
        /// Enum Status
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Status
        {
            /// <summary>
            /// The ok
            /// </summary>
            [EnumeratorExtension("OK")]
            Ok = 1,

            /// <summary>
            /// The error
            /// </summary>
            [EnumeratorExtension("ERROR")]
            Error = 0
        }

        /// <summary>
        /// Enum Log
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public enum Log
        {
            /// <summary>
            /// The error
            /// </summary>
            Error,

            /// <summary>
            /// The information
            /// </summary>
            Info,

            /// <summary>
            /// The warn
            /// </summary>
            Warn,

            /// <summary>
            /// The debug
            /// </summary>
            Debug
        }

        /// <summary>
        /// Enum OrderByMethod
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public enum OrderByMethod
        {
            /// <summary>
            /// The order by
            /// </summary>
            OrderBy,
            /// <summary>
            /// The order by descending
            /// </summary>
            OrderByDescending
        }

        /// <summary>
        /// Enum Message
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Message
        {
            /// <summary>
            /// The footer registration
            /// </summary>
            FooterRegistration,
            /// <summary>
            /// The message registration
            /// </summary>
            MessageRegistration,
            /// <summary>
            /// The subject registration
            /// </summary>
            SubjectRegistration
        }

        /// <summary>
        /// Enum Parameter
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Parameter
        {
            /// <summary>
            /// The API key send grid
            /// </summary>
            ApiKeySendGrid,
            /// <summary>
            /// The company domain
            /// </summary>
            CompanyDomain,
            /// <summary>
            /// The company name
            /// </summary>
            CompanyName,
            /// <summary>
            /// The company notification mail
            /// </summary>
            CompanyNotificationMail,
            /// <summary>
            /// The generic password
            /// </summary>
            GenericPassword,
            /// <summary>
            /// The template identifier notification
            /// </summary>
            TemplateIdNotification
        }

        /// <summary>
        /// Enum Language
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum Language
        {
            /// <summary>
            /// The es
            /// </summary>
            [EnumeratorExtension("es")]
            Es,
            /// <summary>
            /// The en
            /// </summary>
            [EnumeratorExtension("en")]
            En
        }

        /// <summary>
        /// Enum General
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum General
        {
            /// <summary>
            /// The default identifier
            /// </summary>
            DefaultId = 0
        }

        /// <summary>
        /// Enum SolicitudeStatu
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum SolicitudeStatu
        {
            /// <summary>
            /// The registered
            /// </summary>
            Registered = 3,
            /// <summary>
            /// The in progress
            /// </summary>
            InProgress = 4,
            /// <summary>
            /// The modification
            /// </summary>
            Modification = 5,
            /// <summary>
            /// The in record
            /// </summary> 
            InRecord = 6,
            /// <summary>
            /// The rejected
            /// </summary>
            Rejected = 7,
            /// <summary>
            /// The managed
            /// </summary>
            Managed = 8,
            /// <summary>
            /// The temporary
            /// </summary>
            Temporary = 9,
            /// <summary>
            /// The pending
            /// </summary>
            Pending = 95
        }

        /// <summary>
        /// Enum SolicitudeType
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum SolicitudeType
        {
            /// <summary>
            /// The ceation
            /// </summary>
            Ceation = 1,
            /// <summary>
            /// The withdrawal
            /// </summary>
            Withdrawal = 2,
        }

        /// <summary>
        /// Enum Method
        /// </summary>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public enum Method
        {
            /// <summary>
            /// The post
            /// </summary>
            [EnumeratorExtension("CREARDO")]
            Post,
            /// <summary>
            /// The put
            /// </summary>
            [EnumeratorExtension("ACTUALIZADO")]
            Put,
            /// <summary>
            /// The delete
            /// </summary>
            [EnumeratorExtension("BORRADO")]
            Delete
        }

        /// <summary>
        /// Enum CommercialActivityType
        /// </summary>
        /// <remarks>Priscy Antonio Reales</remarks>
        public enum CommercialActivityType
        {
            /// <summary>
            /// The promotions
            /// </summary>
            Promotions = 12,
            /// <summary>
            /// The discount kind
            /// </summary>
            DiscountKind = 13,
            /// <summary>
            /// The discount value
            /// </summary>
            DiscountValue = 14,
            /// <summary>
            /// The financial discount
            /// </summary>
            FinancialDiscount = 15,
            /// <summary>
            /// The events
            /// </summary>
            Events = 16,
            /// <summary>
            /// The zero value product
            /// </summary>
            ZeroValueProduct = 17,
            /// <summary>
            /// The loyalty
            /// </summary>
            Loyalty = 18,
            /// <summary>
            /// The redemption
            /// </summary>
            Redemption = 19,
            /// <summary>
            /// The abseiling
            /// </summary>
            Abseiling = 20,
            /// <summary>
            /// The price discount
            /// </summary>
            PriceDiscount = 21,
        }

        public enum AzDSettings
        {
            [EnumeratorExtension("client_id")]
            ClientId,

            [EnumeratorExtension("scope")]
            Scope,

            [EnumeratorExtension("client_secret")]
            ClientSecret,

            [EnumeratorExtension("grant_type")]
            GrantType
        }

        public enum ApiManagerHeaderSAP
        {
            [EnumeratorExtension("Ocp-Apim-Subscription-Key")]
            SubscriptionKey,

            [EnumeratorExtension("Ocp-Apim-Trace")]
            Trace,

        }
    }
}