using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gatchan.Base.Standard.Abstracts
{
    public abstract class DirRecursiveHandler
    {
        public void RecusiveSearch(string path)
        {
            BeforeRecusiveSearch(path);
            DoRecusiveSearch(path);
            AfterRecusiveSearch(path);
        }

        public async Task RecusiveSearchAsync(string path)
        {
            await BeforeRecusiveSearchAsync(path);
            await DoRecusiveSearchAsync(path);
            await AfterRecusiveSearchAsync(path);
        }

        protected virtual void BeforeRecusiveSearch(string path) { }
        protected virtual Task BeforeRecusiveSearchAsync(string path)
        {
            BeforeRecusiveSearch(path);
            return Task.CompletedTask;
        }

        protected virtual void DoRecusiveSearch(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path) || path.EndsWith("System Volume Information"))
                return;

            var (dirs, isAccessable) = GetEnumerateDirectories(path);
            if (!isAccessable)
                return;
            if (dirs.Any())
            {
                var innerDirs = Directory.EnumerateDirectories(path);
                ProcessDirs(innerDirs);
                foreach (var dir in innerDirs)
                {
                    DoRecusiveSearch(dir);
                }
            }

            var files = Directory.EnumerateFiles(path);
            ProcessFiles(path, files);
        }

        protected virtual async Task DoRecusiveSearchAsync(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path) || path.EndsWith("System Volume Information"))
                return;

            var (dirs, isAccessable) = GetEnumerateDirectories(path);
            if (!isAccessable)
                return;
            if (dirs.Any())
            {
                var innerDirs = Directory.EnumerateDirectories(path);
                await ProcessDirsAsync(innerDirs);
                foreach (var dir in innerDirs)
                {
                    await DoRecusiveSearchAsync(dir);
                }
            }

            var files = Directory.EnumerateFiles(path);
            await ProcessFilesAsync(path, files);
        }

        protected virtual void AfterRecusiveSearch(string path) { }
        protected virtual Task AfterRecusiveSearchAsync(string path)
        {
            AfterRecusiveSearch(path);
            return Task.CompletedTask;
        }

        private (IEnumerable<string> dirs, bool isAccessable) GetEnumerateDirectories(string path)
        {
            try
            {
                if (path is null)
                {
                    throw new System.ArgumentNullException(nameof(path));
                }

                return (Directory.EnumerateDirectories(path), true);
            }
            catch
            {
                return (Enumerable.Empty<string>(), false);
            }
        }

        protected virtual void ProcessDirs(IEnumerable<string> innerDirs) { }
        protected virtual Task ProcessDirsAsync(IEnumerable<string> innerDirs)
        {
            ProcessDirs(innerDirs);
            return Task.CompletedTask;
        }

        protected virtual void ProcessFiles(string path, IEnumerable<string> files) { }
        protected virtual Task ProcessFilesAsync(string path, IEnumerable<string> files)
        {
            ProcessFiles(path, files);
            return Task.CompletedTask;
        }
    }
}
