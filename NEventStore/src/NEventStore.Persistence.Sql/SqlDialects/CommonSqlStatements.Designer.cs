﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEventStore.Persistence.Sql.SqlDialects {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonSqlStatements {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonSqlStatements() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NEventStore.Persistence.Sql.SqlDialects.CommonSqlStatements", typeof(CommonSqlStatements).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT
        ///INTO Snapshots
        /// ( BucketId, StreamId, StreamRevision, Payload )
        ///SELECT @BucketId, @StreamId, @StreamRevision, @Payload
        ////*FROM DUAL*/
        ///WHERE EXISTS
        /// ( SELECT *
        ///     FROM Commits
        ///    WHERE BucketId = @BucketId
        ///      AND StreamId = @StreamId
        ///      AND (StreamRevision - Items) &lt;= @StreamRevision )
        ///AND NOT EXISTS
        /// ( SELECT *
        ///     FROM Snapshots
        ///    WHERE BucketId = @BucketId
        ///      AND StreamId = @StreamId
        ///      AND StreamRevision = @StreamRevision );.
        /// </summary>
        internal static string AppendSnapshotToCommit {
            get {
                return ResourceManager.GetString("AppendSnapshotToCommit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM Snapshots WHERE BucketId =@BucketId AND StreamId = @StreamId;
        ///DELETE FROM Commits WHERE BucketId = @BucketId AND StreamId = @StreamId;.
        /// </summary>
        internal static string DeleteStream {
            get {
                return ResourceManager.GetString("DeleteStream", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DROP TABLE Snapshots;
        ///DROP TABLE Commits;.
        /// </summary>
        internal static string DropTables {
            get {
                return ResourceManager.GetString("DropTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT COUNT(*)
        ///  FROM Commits
        /// WHERE BucketId = @BucketId 
        ///   AND StreamId = @StreamId
        ///   AND CommitSequence = @CommitSequence
        ///   AND CommitId = @CommitId;.
        /// </summary>
        internal static string DuplicateCommit {
            get {
                return ResourceManager.GetString("DuplicateCommit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp, CheckpointNumber, Headers, Payload
        ///  FROM Commits
        /// WHERE BucketId = @BucketId 
        ///   AND CheckpointNumber &gt; @CheckpointNumber
        /// ORDER BY CheckpointNumber 
        /// LIMIT @Limit OFFSET @Skip;.
        /// </summary>
        internal static string GetCommitsFromBucketAndCheckpoint {
            get {
                return ResourceManager.GetString("GetCommitsFromBucketAndCheckpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp, CheckpointNumber, Headers, Payload
        ///FROM Commits
        ///WHERE  CheckpointNumber &gt; @CheckpointNumber
        ///ORDER BY CheckpointNumber
        /// LIMIT @Limit OFFSET @Skip;.
        /// </summary>
        internal static string GetCommitsFromCheckpoint {
            get {
                return ResourceManager.GetString("GetCommitsFromCheckpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp, CheckpointNumber, Headers, Payload
        ///  FROM Commits
        /// WHERE BucketId = @BucketId AND CommitStamp &gt;= @CommitStamp
        /// ORDER BY CommitStamp, StreamId, CommitSequence
        /// LIMIT @Limit OFFSET @Skip;.
        /// </summary>
        internal static string GetCommitsFromInstant {
            get {
                return ResourceManager.GetString("GetCommitsFromInstant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp,  CheckpointNumber, Headers, Payload
        ///  FROM Commits
        /// WHERE BucketId = @BucketId
        ///   AND StreamId = @StreamId
        ///   AND StreamRevision &gt;= @StreamRevision
        ///   AND (StreamRevision - Items) &lt; @MaxStreamRevision
        ///   AND CommitSequence &gt; @CommitSequence
        /// ORDER BY CommitSequence
        /// LIMIT @Limit;.
        /// </summary>
        internal static string GetCommitsFromStartingRevision {
            get {
                return ResourceManager.GetString("GetCommitsFromStartingRevision", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp, CheckpointNumber, Headers, Payload
        ///  FROM Commits
        /// WHERE BucketId = @BucketId
        ///   AND CommitStamp &gt;= @CommitStampStart
        ///   AND CommitStamp &lt; @CommitStampEnd
        /// ORDER BY CommitStamp, StreamId, CommitSequence
        /// LIMIT @Limit OFFSET @Skip;.
        /// </summary>
        internal static string GetCommitsFromToInstant {
            get {
                return ResourceManager.GetString("GetCommitsFromToInstant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT *
        ///  FROM Snapshots
        /// WHERE BucketId = @BucketId
        ///   AND StreamId = @StreamId
        ///   AND StreamRevision &lt;= @StreamRevision
        /// ORDER BY StreamRevision DESC
        /// LIMIT 1;.
        /// </summary>
        internal static string GetSnapshot {
            get {
                return ResourceManager.GetString("GetSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT C.BucketId, C.StreamId, C.StreamIdOriginal, MAX(C.StreamRevision) AS StreamRevision, MAX(COALESCE(S.StreamRevision, 0)) AS SnapshotRevision
        ///  FROM Commits AS C
        /// LEFT OUTER JOIN Snapshots AS S
        ///    ON C.BucketId = @BucketId
        ///   AND C.StreamId = S.StreamId
        ///   AND C.StreamRevision &gt;= S.StreamRevision
        /// GROUP BY C.StreamId, C.BucketId, C.StreamIdOriginal
        ///HAVING MAX(C.StreamRevision) &gt;= MAX(COALESCE(S.StreamRevision, 0)) + @Threshold
        /// ORDER BY C.StreamId
        /// LIMIT @Limit;.
        /// </summary>
        internal static string GetStreamsRequiringSnapshots {
            get {
                return ResourceManager.GetString("GetStreamsRequiringSnapshots", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT BucketId, StreamId, StreamIdOriginal, StreamRevision, CommitId, CommitSequence, CommitStamp, CheckpointNumber, Headers, Payload
        ///  FROM Commits
        /// WHERE Dispatched = 0
        /// ORDER BY CheckpointNumber
        /// LIMIT @Limit OFFSET @Skip;.
        /// </summary>
        internal static string GetUndispatchedCommits {
            get {
                return ResourceManager.GetString("GetUndispatchedCommits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE Commits
        ///   SET Dispatched = 1
        /// WHERE BucketId = @BucketId
        ///   AND StreamId = @StreamId
        ///   AND CommitSequence = @CommitSequence;.
        /// </summary>
        internal static string MarkCommitAsDispatched {
            get {
                return ResourceManager.GetString("MarkCommitAsDispatched", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM Snapshots WHERE BucketId = @BucketId;
        ///DELETE FROM Commits WHERE BucketId = @BucketId;.
        /// </summary>
        internal static string PurgeBucket {
            get {
                return ResourceManager.GetString("PurgeBucket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM Snapshots;
        ///DELETE FROM Commits;.
        /// </summary>
        internal static string PurgeStorage {
            get {
                return ResourceManager.GetString("PurgeStorage", resourceCulture);
            }
        }
    }
}
