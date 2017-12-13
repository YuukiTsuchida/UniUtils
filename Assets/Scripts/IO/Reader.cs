using System.IO;


namespace UniUtil
{
    namespace IO
    {
        public static class Reader
        {
            /// <summary>
            /// ファイルストリームを作成する.
            /// </summary>
            /// <param name="filePath"> フルパス.</param>
            /// <returns>ファイルストリーム </returns>
            private static FileStream CreateStream( string filePath )
            {
                FileInfo fileInfo = new FileInfo( filePath );
                return fileInfo.Open( FileMode.Open, FileAccess.Read );
            }

            /// <summary>
            /// バイトデータでデータを読み込む.
            /// </summary>
            /// <param name="">ファイルパス.</param>
            /// <returns>読み込んだデータ </returns>
            public static byte[] ReadBytes( string filePath )
            {
                if( !System.IO.File.Exists( filePath ) )
                {
                    Debug.Log( "no such file" );
                    return null;
                }

                FileStream fileStream = null;
                byte[] readData = null;

                try
                {
                    fileStream = CreateStream( filePath );
                    using( BinaryReader binaryReader = new BinaryReader( fileStream ) )
                    {
                        readData = new byte[fileStream.Length];
                        binaryReader.Read( readData, 0, readData.Length );
                    }
                }
                catch( IOException exception )
                {
                    Debug.LogError( exception.GetType() + "\n"  + exception.Message );

                    readData = null;
                }
                finally
                {
                    if( fileStream != null )
                    {
                        fileStream.Dispose();
                    }
                }

                return readData;
            }

            /// <summary>
            /// string型に変換して返す.
            /// </summary>
            /// <param name="filePath">ファイルパス.</param>
            /// <returns> 読み込んだデータ.</returns>
            public static string ReadText( string filePath )
            {
                byte[] readData = ReadBytes( filePath );

                if( readData == null )
                {
                    return "";
                }

                return System.Text.Encoding.UTF8.GetString( readData );
            }

        }
    }
}
