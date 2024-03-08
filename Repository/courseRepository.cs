using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;

namespace shift6.Repository
{
    public class courseRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public courseRepository()  //constructor
        {
            con = new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<course> getAll()
        {
            List<course> data = new List<course>();
            using (con)
            {
                con.Open();
                string _query = "select * from course order by name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new course() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString() });
                    }

                }
            }
            return data;

        }


        public course get_by_id(int id)
        {
            course data = new course();
            using (con)
            {
                con.Open();
                string _query = $"select * from course where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new course() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString() };
                }
            }
            return data;
        }

        public bool create(string name)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into course values('{name}')";
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
                string _query = $"update course set name='{newname}' where id={id}";
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
                string _query = $"delete from course where id={id}";
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
