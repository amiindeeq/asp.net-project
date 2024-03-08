using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;



namespace shift6.Repository
{
    public class studRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public studRepository()  //constructor
        {
            con = new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<stud> getAll()
        {
            List<stud> data = new List<stud>();
            using (con)
            {
                con.Open();
                string _query = "select * from student order by name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new stud() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), age = Convert.ToInt32(dr["age"]), number = dr["number"].ToString() });
                    }

                }
            }
            return data;

        }


        public stud get_by_id(int id)
        {
            stud data = newstud();
            using (con)
            {
                con.Open();
                string _query = $"select * from student where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new stud() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), age = Convert.ToInt32(dr["age"]), number = dr["number"].ToString() };
                }
            }
            return data;
        }

        private static stud newstud()
        {
            return new();
        }

        public bool Create(string name , int age, string number)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into student values('{name}',{age},'{number}')";
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

        public bool update(int id, string newname, int newage, string newnumber)
        {
            using (con)
            {
                con.Open();
                string _query = $"update student set name='{newname}' age={newage} number='{newnumber}' where id={id}";
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
                string _query = $"delete from student where id={id}";
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


