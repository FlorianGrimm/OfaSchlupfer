namespace OfaSchlupfer.Elementary {
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// Utility class for Meassure
    /// </summary>
    public sealed class SqlMeassure : IDisposable {
        private SqlConnection _Connection;

        /// <summary>
        /// Holds the messages
        /// </summary>
        public readonly List<string> Messages;

        /// <summary>
        /// Holds the errors
        /// </summary>
        public readonly List<string> Errors;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlMeassure"/> class.
        /// </summary>
        /// <param name="connection">the related connection to wire.</param>
        public SqlMeassure(SqlConnection connection) {
            this._Connection = connection;
            this.Messages = new List<string>();
            this.Errors = new List<string>();
            connection.InfoMessage += this.Connection_InfoMessage;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SqlMeassure"/> class.
        /// </summary>
        ~SqlMeassure() {
            this.Dispose(false);
        }

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e) {
            this.Messages.Add(e.Message);
            if (e.Errors != null) {
                foreach (SqlError sqlError in e.Errors) {
                    this.Errors.Add(sqlError.ToString());
                }
            }
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                using (var c = this._Connection) {
                    this._Connection = null;
                    if (c != null) {
                        c.InfoMessage -= this.Connection_InfoMessage;
                    }
                }
            } else {
                try {
                    using (var c = this._Connection) {
                        this._Connection = null;
                        if (c != null) {
                            c.InfoMessage -= this.Connection_InfoMessage;
                        }
                    }
                } catch { }
            }
        }

        /// <summary>
        /// unwire handler.
        /// </summary>
        public void Dispose() {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
