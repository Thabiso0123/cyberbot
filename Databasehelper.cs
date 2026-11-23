using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ChatBot
{
    internal class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            connectionString =
                ConfigurationManager.ConnectionStrings["CyberSecurityAwarenessChatbotDatabase"].ConnectionString;
        }

        public void InitializeDatabase()
        {
            string checkSql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tasks' AND xtype='U')
                BEGIN
                    CREATE TABLE Tasks (
                        TaskID      INT IDENTITY(1,1) PRIMARY KEY,
                        Title       NVARCHAR(100) NOT NULL,
                        Description NVARCHAR(MAX) NOT NULL,
                        ReminderDate DATETIME NULL,
                        IsCompleted  BIT DEFAULT 0,
                        DateCreated  DATETIME DEFAULT GETDATE()
                    );
                END

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ActivityLog' AND xtype='U')
                BEGIN
                    CREATE TABLE ActivityLog (
                        LogID      INT IDENTITY(1,1) PRIMARY KEY,
                        Action     NVARCHAR(255) NOT NULL,
                        ActionTime DATETIME DEFAULT GETDATE()
                    );
                END

                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='QuizResults' AND xtype='U')
                BEGIN
                    CREATE TABLE QuizResults (
                        ResultID       INT IDENTITY(1,1) PRIMARY KEY,
                        Score          INT NOT NULL,
                        TotalQuestions INT NOT NULL,
                        DateTaken      DATETIME DEFAULT GETDATE()
                    );
                END";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(checkSql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public int AddTask(string title, string description, DateTime? reminderDate)
        {
            string insertSql = @"
                INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted)
                VALUES (@title, @description, @reminderDate, 0);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description ?? string.Empty);
                    command.Parameters.AddWithValue("@reminderDate",
                        reminderDate.HasValue ? (object)reminderDate.Value : DBNull.Value);

                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }

        public List<CyberTask> GetAllTasks()
        {
            List<CyberTask> tasks = new List<CyberTask>();

            string selectSql =
                "SELECT TaskID, Title, Description, ReminderDate, IsCompleted " +
                "FROM Tasks ORDER BY TaskID DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectSql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new CyberTask
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("TaskID")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                                            ? string.Empty
                                            : reader.GetString(reader.GetOrdinal("Description")),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime(reader.GetOrdinal("ReminderDate")),
                            IsCompleted = reader.GetBoolean(reader.GetOrdinal("IsCompleted"))
                        });
                    }
                }
            }

            return tasks;
        }

        public void SetReminder(int taskId, DateTime reminderDate)
        {
            string updateSql =
                "UPDATE Tasks SET ReminderDate = @reminderDate WHERE TaskID = @id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@reminderDate", reminderDate);
                    command.Parameters.AddWithValue("@id", taskId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void MarkCompleted(int taskId)
        {
            string updateSql = "UPDATE Tasks SET IsCompleted = 1 WHERE TaskID = @id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@id", taskId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            string deleteSql = "DELETE FROM Tasks WHERE TaskID = @id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(deleteSql, connection))
                {
                    command.Parameters.AddWithValue("@id", taskId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertActivityLog(string action)
        {
            string insertSql =
                "INSERT INTO ActivityLog (Action) VALUES (@action);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@action", action);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertQuizResult(int score, int totalQuestions)
        {
            string insertSql =
                "INSERT INTO QuizResults (Score, TotalQuestions) VALUES (@score, @total);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@score", score);
                    command.Parameters.AddWithValue("@total", totalQuestions);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}