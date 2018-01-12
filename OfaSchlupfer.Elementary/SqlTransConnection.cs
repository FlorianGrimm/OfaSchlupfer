namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// SqlConnection and SqlTransaction.
    /// </summary>
    public sealed class SqlTransConnection : IDisposable {
        private string _ConnectionString;
        private SqlCredential _Credential;
        private SqlConnection _Connection;
        private SqlTransaction _Transaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlTransConnection"/> class.
        /// </summary>
        /// <param name="connectionString">
        ///     The connection used to open the SQL Server database.
        /// </param>
        /// <param name="credential">
        ///     A <see cref="System.Data.SqlClient.SqlCredential"/> object. Default is null;
        /// </param>
        public SqlTransConnection(string connectionString, SqlCredential credential = null) {
            this._ConnectionString = connectionString;
            this._Credential = credential;
            System.GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlTransConnection"/> class.
        /// </summary>
        /// <param name="connection">the connection - can be null.</param>
        /// <param name="transaction">the transaction - can be null.</param>
        public SqlTransConnection(SqlConnection connection, SqlTransaction transaction) {
            if (((object)connection == null) && ((object)transaction != null)) {
                throw new ArgumentNullException(nameof(connection), "connection must be set if transaction");
            }
            this._Connection = connection;
            this._Transaction = transaction;
            if ((object)connection == null) {
                System.GC.SuppressFinalize(this);
            }
        }

        ~SqlTransConnection() {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        public string ConnectionString {
            get {
                return this._ConnectionString;
            }

            set {
                if ((object)this._Connection != null) {
                    using (var c = this._Connection) {
                        this._Connection = null;
                    }
                    System.GC.SuppressFinalize(this);
                }
                this._ConnectionString = value;
            }
        }

        /// <summary>
        /// Gets or sets the Connection.
        /// </summary>
        public SqlConnection Connection {
            get {
                if ((object)this._Connection == null) {
                    if (string.IsNullOrEmpty(this._ConnectionString)) {
                        // cannot create a connection without a connection string.
                    } else {
                        this._Connection = new SqlConnection(this._ConnectionString, this._Credential);
                    }
                }
                return this._Connection;
            }

            set {
                if (ReferenceEquals(this._Connection, value)) {
                    return;
                }
                var suppress = ((object)this._Connection != null) && ((object)value != null);
                if ((object)this._Connection != null) {
                    using (var c = this._Connection) {
                        this._Connection = null;
                        if (!suppress) {
                            System.GC.SuppressFinalize(this);
                        }
                    }
                }
                this._Connection = value;
                if ((object)this._Connection != null) {
                    if (!suppress) {
                        System.GC.ReRegisterForFinalize(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Transaction.
        /// </summary>
        public SqlTransaction Transaction {
            get {
                return this._Transaction;
            }
        }

        /// <summary>
        /// Open the connection - if needed.
        /// </summary>
        public void Open() {
            var connection = this.Connection;
            if ((object)connection == null) {
                throw new InvalidOperationException("No connection, no connectionString.");
            }
            if (connection.State != System.Data.ConnectionState.Open) {
                connection.Open();
            }
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close() {
            var transaction = this._Transaction;
            if ((object)transaction != null) {
                using (transaction) {
                    this._Transaction = null;
                    transaction.Rollback();
                }
            }
            var connection = this.Connection;
            if ((object)connection != null) {
                if (connection.State == System.Data.ConnectionState.Open) {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Start a transaction
        /// </summary>
        /// <param name="isolationLevel">default Unspecified</param>
        /// <param name="transactionName">default null</param>
        /// <returns>a new trans action - null if a transaction already exists.</returns>
        public SqlTransaction BeginTransaction(System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.Unspecified, string transactionName = null) {
            if (this._Transaction == null) {
                var transaction = this.Connection.BeginTransaction(isolationLevel, transactionName);
                this._Transaction = transaction;
                return transaction;
            } else {
                return null;
            }
        }

        /// <summary>
        /// Commit the transaction - if the transaction is the same as this.Transaction.
        /// </summary>
        /// <param name="transaction">transaction to commit.</param>
        public void Commit(SqlTransaction transaction) {
            var thisTransaction = this._Transaction;
            if ((object)thisTransaction != null) {
                if (ReferenceEquals(thisTransaction, transaction)) {
                    using (thisTransaction) {
                        thisTransaction.Commit();
                        this._Transaction = null;
                    }
                }
            }
        }

        /// <summary>
        /// Rollback the transaction - if the transaction is the same as this.Transaction.
        /// </summary>
        /// <param name="transaction">transaction to commit.</param>
        public void Rollback(SqlTransaction transaction) {
            var thisTransaction = this._Transaction;
            if ((object)thisTransaction != null) {
                if (ReferenceEquals(thisTransaction, transaction)) {
                    using (thisTransaction) {
                        thisTransaction.Rollback();
                        this._Transaction = null;
                    }
                }
            }
        }

        /// <summary>
        /// Rollback the transaction - if the transaction exists..
        /// </summary>
        public void Rollback() {
            var thisTransaction = this._Transaction;
            if ((object)thisTransaction != null) {
                using (thisTransaction) {
                    thisTransaction.Rollback();
                    this._Transaction = null;
                }
            }
        }

        /// <summary>
        /// Creates a SqlCommand
        /// </summary>
        /// <param name="commandType">Text or SP</param>
        /// <param name="commandText">Test or Name</param>
        /// <returns>a new command bound to the connection and transaction.</returns>
        public SqlCommand SqlCommand(System.Data.CommandType commandType, string commandText) {
            var command = new SqlCommand();
            command.Connection = this._Connection;
            command.CommandText = commandText;
            command.CommandType = commandType;
            if (this.Transaction != null) {
                command.Transaction = this.Transaction;
            }
            return command;
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                using (var c = this._Connection) {
                    using (var t = this._Transaction) {
                        this._Transaction = null;
                        this._Connection = null;
                    }
                }
            } else {
                try {
                    using (var c = this._Connection) {
                        using (var t = this._Transaction) {
                            this._Transaction = null;
                            this._Connection = null;
                        }
                    }
                } catch {
                    // will be thrown, since this is the finalizer thread..
                }
            }
        }

        public void Dispose() {
            this.Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
