namespace PipelineDesignPattern
{
    internal class ProductController
   {
        public void GetAllUser()
        {
            Console.WriteLine("Return all user");
        }

        public void GetUserById(HttpContext context)
        {
            Console.WriteLine("Return User by Id");
        }
    }
}
