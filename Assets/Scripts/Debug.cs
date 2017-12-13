using System;
using System.Diagnostics;
using System.Reflection;

namespace UniUtil
{
    /**
     * <summary>
     * デバッグ機能. 
     * </summary>
     */
    public static class Debug
    {
        [Conditional("DEBUG")]
        public static void Break()
        {
            UnityEngine.Debug.Break();
        }

        [Conditional("DEBUG")]
        public static void Log( object message )
        {
            UnityEngine.Debug.Log( message );
        }

        [Conditional("DEBUG")]
        public static void Log( object message, UnityEngine.Object context )
        {
            UnityEngine.Debug.Log( message, context );
        }

        [Conditional("DEBUG")]
        public static void LogError( object message )
        {
            UnityEngine.Debug.LogError( message );
        }

        [Conditional("DEBUG")]
        public static void LogError( object message, UnityEngine.Object context )
        {
            UnityEngine.Debug.LogError( message, context );
        }

        [Conditional("DEBUG")]
        public static void LogWarning( object message )
        {
            UnityEngine.Debug.LogWarning( message );
        }

        [Conditional("DEBUG")]
        public static void LogWarning( object message, UnityEngine.Object context )
        {
            UnityEngine.Debug.LogWarning( message, context );
        }

        [Conditional("DEBUG")]
        public static void DrawLine( UnityEngine.Vector3 start, UnityEngine.Vector3 end )
        {
            UnityEngine.Debug.DrawLine( start, end );
        }

        [Conditional("DEBUG")]
        public static void Assert( bool condition )
        {
            if( !condition )
            {
                throw new Exception();
            }
        }

        [Conditional("DEBUG")]
        public static void Assert( bool condition, string message )
        {
            if( !condition )
            {
                throw new Exception( message );
            }
        }

        [Conditional("DEBUG")]
        public static void DrawLine( UnityEngine.Vector3 start, UnityEngine.Vector3 end, UnityEngine.Color color, float duration = 0f, bool depthTest = true )
        {
            UnityEngine.Debug.DrawLine( start, end, color, duration, depthTest );
        }

        [Conditional("DEBUG")]
        public static void DrawRay( UnityEngine.Vector3 start, UnityEngine.Vector3 dir )
        {
            UnityEngine.Debug.DrawRay( start, dir );
        }

        [Conditional("DEBUG")]
        public static void DrawRay( UnityEngine.Vector3 start, UnityEngine.Vector3 dir, UnityEngine.Color color, float duration = 0f, bool depthTest = true )
        {
            UnityEngine.Debug.DrawRay( start, dir, color, duration, depthTest );
        }


        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        public static void MethodRuntimeCalculate( Action action )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
#else
            action();
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        public static void MethodRuntimeCalculate<FirstParam>( Action<FirstParam> action, FirstParam firstParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            action( firstParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
#else
            action( firstParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="secondParam">第二引数.</param>
        public static void MethodRuntimeCalculate<FirstParam, SecondParam>(
                Action<FirstParam, SecondParam> action,
                FirstParam firstParam,
                SecondParam secondParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            action( firstParam, secondParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
#else
            action( firstParam, secondParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="thirdParam">第二引数.</param>
        /// <param name="thirdParam">第三引数.</param>
        public static void MethodRuntimeCalculate<FirstParam, SecondParam, ThirdParam>(
                Action<FirstParam, SecondParam, ThirdParam> action,
                FirstParam firstParam,
                SecondParam secondParam,
                ThirdParam  thirdParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            action( firstParam, secondParam, thirdParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
#else
            action( firstParam, secondParam, thirdParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="thirdParam">第二引数.</param>
        /// <param name="thirdParam">第三引数.</param>
        /// <param name="fourthParam">第四引数.</param>
        public static void MethodRuntimeCalculate<FirstParam, SecondParam, ThirdParam, FourthParam>(
                Action<FirstParam, SecondParam, ThirdParam, FourthParam> action,
                FirstParam firstParam,
                SecondParam secondParam,
                ThirdParam  thirdParam,
                FourthParam fourthParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            action( firstParam, secondParam, thirdParam, fourthParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
#else
            action( firstParam, secondParam, thirdParam, fourthParam );
#endif
        }

        /// <summary>
        /// 戻り値があるメソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <returns>関数の戻り値.</returns>
        public static ReturnType MethodRuntimeCalculateWithReturn<ReturnType>( Func<ReturnType> action )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            ReturnType returnData = action();
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
            return returnData;
#else
            return action();
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <returns>関数の戻り値.</returns>
        public static ReturnType MethodRuntimeCalculateWithReturn<FirstParam, ReturnType>( Func<FirstParam, ReturnType> action, FirstParam firstParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            ReturnType returnData = action( firstParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
            return returnData;
#else
            return action( firstParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="thirdParam">第二引数.</param>
        /// <returns>関数の戻り値.</returns>
        public static ReturnType MethodRuntimeCalculateWithReturn<FirstParam, SecondParam, ReturnType>(
                Func<FirstParam, SecondParam, ReturnType> action,
                FirstParam firstParam,
                SecondParam secondParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            ReturnType returnData = action( firstParam, secondParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
            return returnData;
#else
            return action( firstParam, secondParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="thirdParam">第二引数.</param>
        /// <param name="thirdParam">第三引数.</param>
        /// <returns>関数の戻り値.</returns>
        public static ReturnType MethodRuntimeCalculateWithReturn<FirstParam, SecondParam, ThirdParam, ReturnType>(
                Func<FirstParam, SecondParam, ThirdParam, ReturnType> action,
                FirstParam firstParam,
                SecondParam secondParam,
                ThirdParam  thirdParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            ReturnType returnData = action( firstParam, secondParam, thirdParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
            return returnData;
#else
            return action( firstParam, secondParam, thirdParam );
#endif
        }

        /// <summary>
        /// メソッドの実行時間計測(ミリ秒).
        /// </summary>
        /// <param name="action">計測したい関数.</param>
        /// <param name="firstParam">第一引数.</param>
        /// <param name="thirdParam">第二引数.</param>
        /// <param name="thirdParam">第三引数.</param>
        /// <param name="fourthParam">第四引数.</param>
        /// <returns>関数の戻り値.</returns>
        public static ReturnType MethodRuntimeCalculateWithReturn<FirstParam, SecondParam, ThirdParam, FourthParam, ReturnType>(
                Func<FirstParam, SecondParam, ThirdParam, FourthParam, ReturnType> action,
                FirstParam firstParam,
                SecondParam secondParam,
                ThirdParam  thirdParam,
                FourthParam fourthParam )
        {
#if DEBUG
            Stopwatch stopwatch = Stopwatch.StartNew();
            ReturnType returnData = action( firstParam, secondParam, thirdParam, fourthParam );
            stopwatch.Stop();

            Log( string.Format( "{0} time : {1} msec", action.Method.ToString(), stopwatch.ElapsedMilliseconds ) );
            return returnData;
#else
            return action( firstParam, secondParam, thirdParam, fourthParam );
#endif
        }
    }
}
