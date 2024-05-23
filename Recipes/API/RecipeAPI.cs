using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.API
{
    internal class RecipeAPI
    {
        public MySqlConnectionStringBuilder builder;

        public RecipeAPI()
        {
            builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Port = 3306;
            builder.UserID = "Landon";
            builder.Password = "robots";
            builder.Database = "recipes";
        }

        public bool login(string userName, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("select user_id, password, username from user where username = ?;", connection);
                command.Parameters.Add(new MySqlParameter("username", userName));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string storedHash = reader.GetString(1);
                    if(Hasher.Verify(password, storedHash))
                    {
                        reader.Close();
                        command.Dispose();
                        connection.Close();
                        return true;
                    }
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return false;
            }
        }

        public List<Recipies> getRecipes()
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                var recipies = new List<Recipies>();
                connection.Open();
                var command = new MySqlCommand("select r.recipe_id, r.recipe_name, r.recipe_desc, t.recipe_type_name, u.username\r\n" +
                                               "from (recipe r join recipe_type t using (recipe_type_id)) join user u on r.owner_id = u.user_id;", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    recipies.Add(new Recipies
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Type = reader.GetString(3),
                        Owner = reader.GetString(4),
                    });
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return recipies;
            }
        }

        public List<Ingredient> GetIngredients(int recipeID)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                var ingrediants = new List<Ingredient>();
                connection.Open();

                var command = new MySqlCommand("select * from ingrediant where recipe_id = ?;", connection);
                command.Parameters.Add(new MySqlParameter("recipe_id", recipeID));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ingrediants.Add(new Ingredient
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Amount = reader.GetDouble(2),
                        Unit = reader.GetString(3),
                        Cost = reader.GetDouble(4),
                    });
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return ingrediants;
            }
        }

        public List<RecipeSteps> GetSteps(int recipeID)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                var ingrediants = new List<RecipeSteps>();
                connection.Open();

                var command = new MySqlCommand("select * from recipe_steps where recipe_id = ?;", connection);
                command.Parameters.Add(new MySqlParameter("recipe_id", recipeID));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ingrediants.Add(new RecipeSteps
                    {
                        ID = reader.GetInt32(0),
                        StepNum = reader.GetInt32(1),
                        Step = reader.GetString(2),
                        RecipeID = reader.GetInt32(3),
                        StepName = reader.GetString(4),
                    });
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return ingrediants;
            }
        }

        public bool createRecipe(string name, string type, string description, string username)
        {

            int user_id = getUserID(username);
            int recipe_id = getTypeID(type);

            if (recipe_id == -1)
            {
                createNewType(type);
                recipe_id = getTypeID(type);
            }

            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                var recipies = new List<Recipies>();
                connection.Open();
                var command = new MySqlCommand("insert into recipe values (recipe_id, @name, @desc, @userID, @typeID);", connection);
                command.Parameters.Add(new MySqlParameter("@name", name));
                command.Parameters.Add(new MySqlParameter("@desc", description));
                command.Parameters.Add(new MySqlParameter("@userID", user_id));
                command.Parameters.Add(new MySqlParameter("@typeID", recipe_id));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
                return true;
            }
        }

        private int getUserID(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                int id = -1;
                connection.Open();
                var command = new MySqlCommand("select user_id from user where username = ?;", connection);
                command.Parameters.Add(new MySqlParameter("username", username));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return id;
            }
        }

        private int getTypeID(string recipeType)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                int id = -1;
                connection.Open();
                var command = new MySqlCommand("select recipe_type_id from recipe_type where recipe_type_name = ?;", connection);
                command.Parameters.Add(new MySqlParameter("recipe_type_name", recipeType));
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                reader.Close();
                command.Dispose();
                connection.Close();
                return id;
            }
        }

        private void createNewType(string recipeType)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("insert into recipe_type values (recipe_type_id, @type);", connection);
                command.Parameters.Add(new MySqlParameter("@type", recipeType));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }


        public void addStep(string step, int recipeID, int stepNum)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("insert into recipe_steps values (recipe_steps_id, @stepnum, @step, @recipeID, @stepName);", connection);
                command.Parameters.Add(new MySqlParameter("@stepnum", stepNum));
                command.Parameters.Add(new MySqlParameter("@step", step));
                command.Parameters.Add(new MySqlParameter("@recipeID", recipeID));
                command.Parameters.Add(new MySqlParameter("@stepName", "Step " + stepNum));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void addIngredient(string ingredient,  int recipeID, double amount, double cost, string unit)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("insert into ingrediant values (ingrediant_id, @name, @amount, @unit, @cost, @recipeID);", connection);
                command.Parameters.Add(new MySqlParameter("@name", ingredient));
                command.Parameters.Add(new MySqlParameter("@amount", amount));
                command.Parameters.Add(new MySqlParameter("@unit", unit));
                command.Parameters.Add(new MySqlParameter("@cost", cost));
                command.Parameters.Add(new MySqlParameter("@recipeID", recipeID));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void deleteRecipe(int recipeID)
        {
            deleteSteps(recipeID);
            deleteIngredients(recipeID);
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("delete from recipe where recipe_id = @recipeID;", connection);
                command.Parameters.Add(new MySqlParameter("@recipeID", recipeID));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }


        private void deleteSteps(int recipeID)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("delete from recipe_steps where recipe_id = @recipeID;", connection);
                command.Parameters.Add(new MySqlParameter("@recipeID", recipeID));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        private void deleteIngredients(int recipeID)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("delete from ingrediant where recipe_id = @recipeID;", connection);
                command.Parameters.Add(new MySqlParameter("@recipeID", recipeID));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void updateIngredients(Ingredient i)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("update ingrediant set ingrediant_name = @name, ingrediant_amount = @amount, ingrediant_unit = @unit, ingrediant_cost = @cost where ingrediant_id = @id;", connection);
                command.Parameters.Add(new MySqlParameter("@id", i.ID));
                command.Parameters.Add(new MySqlParameter("@name", i.Name));
                command.Parameters.Add(new MySqlParameter("@amount", i.Amount));
                command.Parameters.Add(new MySqlParameter("@unit", i.Unit));
                command.Parameters.Add(new MySqlParameter("@cost", i.Cost));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void updateSteps(RecipeSteps s)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("update recipe_steps set recipe_step_name = @name, recipe_step_num = @num, recipe_steps = @step where recipe_steps_id = @id;", connection);
                command.Parameters.Add(new MySqlParameter("@id", s.ID));
                command.Parameters.Add(new MySqlParameter("@name", s.StepName));
                command.Parameters.Add(new MySqlParameter("@num", s.StepNum));
                command.Parameters.Add(new MySqlParameter("@step", s.Step));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }

        public void updateRecipe(Recipies r)
        {
            using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = new MySqlCommand("update recipe set recipe_name = @name where recipe_id = @id;", connection);
                command.Parameters.Add(new MySqlParameter("@id", r.ID));
                command.Parameters.Add(new MySqlParameter("@name", r.Name));
                var reader = command.ExecuteReader();
                reader.Close();
                command.Dispose();
                connection.Close();
            }
        }
    }
}
