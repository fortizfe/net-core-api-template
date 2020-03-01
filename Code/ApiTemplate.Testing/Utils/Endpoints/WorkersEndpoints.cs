namespace ApiTemplate.Testing.Utils.Endpoints
{
    public static class WorkersEndpoints
    {
        public const string ApiVersion = "api/1.0";

        public static class Get
        {
            public static string GetAll => $"{ApiVersion}/workers";
        }

        public static class Post
        {
        }

        public static class Put
        {
        }

        public static class Delete
        {
        }
    }
}