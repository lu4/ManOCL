using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Collections;

namespace ManOCL
{
    public class Kernels : IEnumerable<Kernel>
    {
        private Kernel[] kernelsArray;
        private Dictionary<String, Kernel> kernelsDictionary;

        private static void Validate(CommandQueue commandQueue, Program program)
        {
            if (commandQueue.Context != program.Context) throw new ArgumentException(Resources.Program_and_CommandQueue_Context_properties_do_not_match);
        }

        internal static Kernels CreateInternal(CommandQueue commandQueue, Program program, Int32 kernelsCount, Int32 kernelInfoBufferSize)
        {
            Validate(commandQueue, program);

            Int32 numKernelsRet = 0;

            CLKernel[] openclKernels = new CLKernel[kernelsCount];

            OpenCLError.Validate(OpenCLDriver.clCreateKernelsInProgram(program.CLProgram, openclKernels.Length, openclKernels, ref numKernelsRet));

            Kernel[] result = new Kernel[numKernelsRet];

            for (int i = 0; i < numKernelsRet; i++)
            {
                result[i] = new Kernel(openclKernels[i], program, commandQueue, kernelInfoBufferSize);
            }

            return new Kernels(result);
        }

        public Kernels(Kernel[] kernels)
        {
            this.kernelsArray = (Kernel[])kernels.Clone();

            this.kernelsDictionary = new Dictionary<String, Kernel>(kernels.Length);

            foreach (Kernel kernel in kernels)
            {
                if (kernelsDictionary.ContainsKey(kernel.Name)) { continue; }

                kernelsDictionary.Add(kernel.Name, kernel);
            }
        }

        public Int32 Count
        {
            get
            {
                return kernelsArray.Length;
            }
        }

        public Kernel this[Int32 index]
        {
            get
            {
                return kernelsArray[index];
            }
        }
        public Kernel this[String name]
        {
            get
            {
                return kernelsDictionary[name];
            }
        }

        public Boolean ContainsKernel(Kernel kernel)
        {
            return kernelsDictionary.ContainsValue(kernel);
        }
        public Boolean ContainsKernelName(String name)
        {
            return kernelsDictionary.ContainsKey(name);
        }

        public IEnumerator<Kernel> GetEnumerator()
        {
            foreach (Kernel kernel in kernelsArray)
            {
                yield return kernel;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Kernel kernel in kernelsArray)
            {
                yield return kernel;
            }
        }

        public static Kernels Create(String source, Dictionary<String, Argument[]> arguments, Int32 kernelInfoBufferSize, Int32 kernelsCount, String programBuildOptions)
        {
            return Create(new String[] { source }, arguments, kernelInfoBufferSize, kernelsCount, programBuildOptions);
        }
        public static Kernels Create(String[] sources, Dictionary<String, Argument[]> arguments, Int32 kernelInfoBufferSize, Int32 kernelsCount, String programBuildOptions)
        {
            return Create(CommandQueue.Default, Program.Create(sources, Context.Default, Context.Default.Devices, programBuildOptions), arguments, kernelInfoBufferSize, kernelsCount);
        }
        public static Kernels Create(CommandQueue commandQueue, Program program, Dictionary<String, Argument[]> arguments, Int32 kernelInfoBufferSize, Int32 kernelsCount)
        {
            Kernels kernels = Kernels.CreateInternal(commandQueue, program, kernelsCount, kernelInfoBufferSize);

            foreach (Kernel kernel in kernels)
            {
                if (arguments.ContainsKey(kernel.Name))
                {
                    kernel.InitializeArguments(arguments[kernel.Name]);
                }
                else
                {
                    throw new ArgumentException(String.Format(Resources.No_arguments_specified_for_kernel, kernel.Name));
                }
            }

            return kernels;
        }
    }
}
