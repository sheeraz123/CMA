using Member.Application.Contracts.Persistence;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Member.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly List<MemberInfo> memberInfos;
		string filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\")) + @"Data\MemberInfo.json";

		public MemberRepository(bool initialize = true)
        {
            memberInfos = new List<MemberInfo>();
            if (initialize)
            {
                memberInfos = ReadJsonFile();

			}
        }
		private List<MemberInfo> ReadJsonFile()
		{
			using StreamReader streamReader = new(filePath);
			var json = streamReader.ReadToEnd();
			List<MemberInfo> members = JsonSerializer.Deserialize<List<MemberInfo>>(json);
			return members;
		}
        private void saveData(List<MemberInfo> memberInfos)
        {
			var jsonData = JsonSerializer.Serialize(memberInfos);
			System.IO.File.WriteAllText(filePath, jsonData);
		}
		public async Task<MemberInfo> AddAsync(MemberInfo memberInfo)
        {
			int id=memberInfos.Select(m=>m.Id).LastOrDefault();
			memberInfo.Id = id + 1;

			memberInfos.Add(memberInfo);
            saveData(memberInfos);
			var resultsTask = Task.Run(() => memberInfos.Where(x => x.Id == memberInfo.Id).SingleOrDefault());
            return await resultsTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result=memberInfos.Where(x=>x.Id==id).SingleOrDefault();        
            if(result==null)
				throw new ArgumentNullException();

			var resultsTask = Task.Run(() => memberInfos.Remove(result));
			saveData(memberInfos);
			return await resultsTask;
        }

        public async Task<IReadOnlyCollection<MemberInfo>> GetAllAsync()
        {
            var resultsTask = Task.Run(() => memberInfos.ToList());
            return await resultsTask;

        }

        public async Task<MemberInfo> GetByIdAsync(int id)
        {
            var resultsTask = Task.Run(() => memberInfos.Where(s => s.Id == id).SingleOrDefault());
            return await resultsTask;

        }

        public async Task<IReadOnlyCollection<MemberInfo>> UpdateAsync(MemberInfo memberInfo)
        {
            if (memberInfo == null)
                throw new ArgumentNullException(nameof(memberInfo));
            MemberInfo? result = memberInfos.FirstOrDefault(temp => temp.Id == memberInfo.Id);
            if (result == null)
				throw new ArgumentNullException(nameof(memberInfo));
			result.FirstName = memberInfo.FirstName;
            result.Email = memberInfo.Email;
            result.LastName = memberInfo.LastName;
            var resultsTask = Task.Run(() => memberInfos.ToList());
            saveData(memberInfos);
            return await resultsTask;
        }
    }
}
