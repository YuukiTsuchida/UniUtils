using System.IO;

namespace UniUtil
{
    namespace IO
    {
        /**
         * <summary>
         * 書き込み用FileStreamラッパークラス. 
         * </summary>
         */
        public static class Writer
        {
            /// <summary>
            /// ファイルストリームを作成する.
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="mode"> 書き込みのタイプ.</param>
            /// <returns> ファイルストリーム </returns>
            private static FileStream CreateStream( string filePath, FileMode mode )
            {
                FileInfo fileInfo = new FileInfo( filePath );
                return fileInfo.Open( mode, FileAccess.Write );
            }

            /// <summary>
            /// データを書き込む.
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="writeData"> 書き込みデータ.</param>
            /// <param name="mode"> 書き込みのタイプ.</param>
            /// <returns>書き込み可否</returns>
            public static bool Write( string filePath, byte[] writeData, FileMode mode )
            {
                // ディレクトリ存在チェック 
                string directoryPath = Path.GetDirectoryName( filePath );
                if( !System.IO.File.Exists( directoryPath  ) )
                {
                    Directory.CreateDirectory( directoryPath );
                }

                FileStream fileStream = null;
                bool result = true;

                try
                {
                    fileStream = CreateStream( filePath, mode ) ;
                    using( BinaryWriter binaryWriter = new BinaryWriter( fileStream ) )
                    {
                        // BinaryStraam側でFileStreamのdisposeを呼ぶのでnullに
                        fileStream = null;

                        binaryWriter.Write( writeData );
                    }
                }
                catch( IOException exception )
                {
                    Debug.LogError( exception.GetType() + "\n"  + exception.Message );
                    result = false;
                }
                finally
                {
                    if( fileStream != null )
                    {
                        fileStream.Dispose();
                    }
                }

                return result;
            }

            /// <summary>
            /// ファイルを作成してデータを書き込む(既に存在する場合は上書き).
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="writeData"> 書き込みデータ.</param>
            /// <returns>書き込み可否</returns>
            public static bool Create( string filePath, byte[] writeData )
            {
                return Write( filePath, writeData, FileMode.Create );
            }

            /// <summary>
            /// ファイルを作成してデータを書き込む(既に存在する場合は上書き).
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="writeData"> 書き込みデータ.</param>
            /// <returns>書き込み可否</returns>
            public static bool Create( string filePath, string writeData )
            {
                byte[] bytesWriteData = System.Text.Encoding.UTF8.GetBytes( writeData );
                return Create( filePath, bytesWriteData );
            }

            /// <summary>
            /// ファイルに追記を行う(存在しない場合新規に作成する).
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="writeData"> 書き込みデータ.</param>
            /// <returns>書き込み可否</returns>
            public static bool Append( string filePath, byte[] writeData )
            {
                return Write( filePath, writeData, FileMode.Append );
            }

            /// <summary>
            /// ファイルに追記を行う(存在しない場合新規に作成する).
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <param name="writeData"> 書き込みデータ.</param>
            /// <returns>書き込み可否</returns>
            public static bool Append( string filePath, string writeData )
            {
                byte[] bytesWriteData = System.Text.Encoding.UTF8.GetBytes( writeData );
                return Append( filePath, bytesWriteData );
            }
        }
    }
}
