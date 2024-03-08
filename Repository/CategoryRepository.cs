using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;

namespace shift6.Repository
{
    public class CategoryRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public CategoryRepository()  //constructor
        {
            con= new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<Category> getAll()
        {
            List<Category> data = new List<Category>(); 
            using (con)
            {
                con.Open();
                string _query = "select * from category order by name asc";
                using(SqlCommand cmd=new SqlCommand(_query,con)) 
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read()) 
                    {
                        data.Add(new Category() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString() }); 
                    }

                }
            }
            return data;    

        }


        public Category get_by_id(int id)
        {
            Category data = new Category();
            using (con)
            {
                con.Open();
                string _query = $"select * from category where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new Category() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString() };
                }
            }
            return data;
        }

        public bool create(string name)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into category values('{name}')";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool update(int id, string newname)
        {
            using (con)
            {
                con.Open();
                string _query = $"update category set name='{newname}' where id={id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool delete(int id)
        {
            using (con)
            {
                con.Open();
                string _query = $"delete from category where id={id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
