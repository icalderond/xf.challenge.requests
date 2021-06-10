namespace ServiceRequest.Helpers
{
    public class HttpStatusMessage
    {
        public const string NotFound = "El recurso no puede ser encontrado en el servidor";
        public const string MethodNotAllowed = "El servidor conoce el método de solicitud, pero se ha desactivado y no se puede utilizar";
        public const string Forbidden = "Usted no tiene permisos requeridos para este recurso";
        public const string InternalServerError = "Hubo un error interno en el servidor";
        public const string Default = "Ocurrio un error al consultar, favor de revisar";

        /*
        Android
        Paginacion
         */
    }
}
