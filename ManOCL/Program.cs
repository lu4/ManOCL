using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ManOCL.Internal.OpenCL;
using ManOCL.Internal;


namespace ManOCL
{
    public partial class Program
    {
        public const String DefaultBuildOptions = "";

        internal CLProgram CLProgram { get; private set; }

        internal Program(CLProgram openclProgram, String[] sources, Context context, Devices devices, String buildOptions)
        {
            this.Context = context;
			this.Devices = devices;
            this.BuildOptions = buildOptions;
            this.CLProgram = openclProgram;
            this.Sources = new ReadOnlyIndexer<String>(sources);
        }

        public Context Context { get; private set; }
		public Devices Devices { get; private set; }

        public String BuildOptions { get; private set; }

        public IList<String> Sources { get; private set; }

        ~Program()
        {
            OpenCLDriver.clReleaseProgram(CLProgram);
        }

        /* Static methods */

        private static SizeT[] GetLengths(String[] sources)
        {
            SizeT[] result = new SizeT[sources.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new SizeT(sources[0].Length);
            }

            return result;
        }

        public static Program Create(String[] sources                                       , String buildOptions)
        {
            return Create(sources, Context.Default, Context.Default.Devices, buildOptions);
        }
        public static Program Create(String[] sources, Devices devices                      , String buildOptions)
        {
            return Create(sources, Context.Default, devices, buildOptions);
        }
        public static Program Create(String[] sources, Context context                      , String buildOptions)
        {
            return Create(sources, context, context.Devices, buildOptions);
        }
        public static Program Create(String[] sources, Context context, Devices devices     , String buildOptions)
        {
            CLError error = CLError.None;

            CLProgram openclProgram = OpenCLDriver.clCreateProgramWithSource(context.CLContext, sources.Length, sources, GetLengths(sources), ref error);

            OpenCLError.Validate(error);

            OpenCLBuildError.ValidateBuild(openclProgram, devices[0], OpenCLDriver.clBuildProgram(openclProgram, devices.Count, devices.OpenCLDeviceArray, buildOptions, null, IntPtr.Zero));

            return new Program(openclProgram, sources, context, devices, buildOptions);
        }

        /* Async api */

        public delegate void CreateCallback(Program program);
        public delegate void CreateCallback<T>(Program program, T userData);

        #region internal abstract class AsyncHelper
        internal abstract class AsyncHelper
        {
            public abstract void Callback();
        }
        #endregion

        #region internal class AsyncHelper<T> : AsyncHelper
        internal class AsyncHelper<T> : AsyncHelper
        {
            public Program Program { get; private set; }
            public CreateCallback<T> CreateCallback { get; private set; }
            public T UserData { get; private set; }

            public AsyncHelper(Program program, CreateCallback<T> createCallback, T userData)
            {
                this.Program = program;
                this.UserData = userData;
                this.CreateCallback = createCallback;
            }

            public override void Callback()
            {
                CreateCallback(Program, UserData);
            }
        }
        #endregion

        #region internal class AsyncHelperParameterless : AsyncHelper
        internal class AsyncHelperParameterless : AsyncHelper
        {
            public Program Program { get; private set; }
            public CreateCallback CreateCallback { get; private set; }

            public AsyncHelperParameterless(Program program, CreateCallback createCallback)
            {
                this.CreateCallback = createCallback;
            }

            public override void Callback()
            {
                CreateCallback(Program);
            }
        }

        #endregion

        internal AsyncHelper AsyncHelperObject { get; private set; }

        private void AsyncCallback(CLProgram program, IntPtr user_data)
        {
            AsyncHelperObject.Callback();

            AsyncHelperObject = null;
        }

        public static void CreateAsync(CreateCallback createCallback, String source, String buildOptions)
        {
            CreateAsync(createCallback, new String[] { source }, Context.Default.Devices, Context.Default, buildOptions);
        }
        public static void CreateAsync(CreateCallback createCallback, String source, Devices devices, String buildOptions)
        {
            CreateAsync(createCallback, new String[] { source }, devices, Context.Default, buildOptions);
        }
        public static void CreateAsync(CreateCallback createCallback, String source, Devices devices, Context context, String buildOptions)
        {
            CreateAsync(createCallback, new String[] { source }, buildOptions);
        }

        public static void CreateAsync(CreateCallback createCallback, String[] sources, String buildOptions)
        {
            CreateAsync(createCallback, sources, Context.Default.Devices, Context.Default, buildOptions);
        }
        public static void CreateAsync(CreateCallback createCallback, String[] sources, Devices devices, String buildOptions)
        {
            CreateAsync(createCallback, sources, devices, Context.Default, buildOptions);
        }
        public static void CreateAsync(CreateCallback createCallback, String[] sources, Devices devices, Context context, String buildOptions)
        {
            CLError error = CLError.None;

            CLProgram openclProgram = OpenCLDriver.clCreateProgramWithSource(context.CLContext, sources.Length, sources, GetLengths(sources), ref error);

            OpenCLError.Validate(error);

            Program program = new Program(openclProgram, sources, context, devices, buildOptions);

            program.AsyncHelperObject = new AsyncHelperParameterless(program, createCallback);

            OpenCLError.Validate(OpenCLDriver.clBuildProgram(openclProgram, devices.Count, devices.OpenCLDeviceArray, buildOptions, program.AsyncCallback, IntPtr.Zero));
        }


        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String source, String buildOptions)
        {
            CreateAsync<T>(createCallback, userData, new String[] { source }, Context.Default.Devices, Context.Default, buildOptions);
        }
        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String source, Devices devices, String buildOptions)
        {
            CreateAsync<T>(createCallback, userData, new String[] { source }, devices, Context.Default, buildOptions);
        }
        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String source, Devices devices, Context context, String buildOptions)
        {
            CreateAsync<T>(createCallback, userData, new String[] { source }, devices, context, buildOptions);
        }

        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String[] sources, String buildOptions)
        {
            CreateAsync<T>(createCallback, userData, sources, Context.Default.Devices, Context.Default, buildOptions);
        }
        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String[] sources, Devices devices, String buildOptions)
        {
            CreateAsync<T>(createCallback, userData, sources, devices, Context.Default, buildOptions);
        }
        public static void CreateAsync<T>(CreateCallback<T> createCallback, T userData, String[] sources, Devices devices, Context context, String buildOptions)
        {
            CLError error = CLError.None;

            CLProgram openclProgram = OpenCLDriver.clCreateProgramWithSource(context.CLContext, sources.Length, sources, GetLengths(sources), ref error);

            OpenCLError.Validate(error);

            Program program = new Program(openclProgram, sources, context, devices, buildOptions);

            program.AsyncHelperObject = new AsyncHelper<T>(program, createCallback, userData);

            OpenCLError.Validate(OpenCLDriver.clBuildProgram(openclProgram, devices.Count, devices.OpenCLDeviceArray, buildOptions, program.AsyncCallback, IntPtr.Zero));
        }
    }
}