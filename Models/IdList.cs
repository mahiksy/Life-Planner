namespace cis4951.sprint.w41._4.Models
{
    public class IdList
    {
          public List<int> ids { get; set; }
          public IdList()
          {
                             
          }

          public void add(int input)
          {
               if(ids == null)
               {
                    ids = new List<int>();
               }
               ids.Add(input);
          }

          public List<int> getid()
          {
               return ids;
          }
    }
}
