﻿using System;
using MongoDB.Driver;

namespace MongoDB.Messaging.Storage
{
    /// <summary>
    /// A helper class for getting MongoDB database connection.
    /// </summary>
    public static class MongoFactory
    {
        /// <summary>
        /// Gets the <see cref="IMongoDatabase"/> with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The MongoDB connection string.</param>
        /// <returns>An instance of <see cref="IMongoDatabase"/>.</returns>
        public static IMongoDatabase GetDatabaseFromConnectionString(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            return GetDatabaseFromMongoUrl(mongoUrl);
        }
        
        /// <summary>
        /// Gets the <see cref="IMongoDatabase" /> with the specified <see cref="MongoUrl" />.
        /// </summary>
        /// <param name="mongoUrl">The mongo URL.</param>
        /// <returns>
        /// An instance of <see cref="IMongoDatabase" />.
        /// </returns>
        public static IMongoDatabase GetDatabaseFromMongoUrl(MongoUrl mongoUrl)
        {
            var client = new MongoClient(mongoUrl);
            var mongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
            return mongoDatabase;
        }

        /// <summary>
        /// Gets the <see cref="MongoUrl" /> with the specified connection name.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>
        /// An instance of <see cref="MongoUrl" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="connectionString"/> is <see langword="null" />.</exception>
        /// <exception cref="ConfigurationErrorsException">No connection string could be found in the application configuration file.</exception>
        public static MongoUrl GetMongoUrl(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");
            
            var mongoUrl = new MongoUrl(connectionString);
            return mongoUrl;
        }
    }
}
