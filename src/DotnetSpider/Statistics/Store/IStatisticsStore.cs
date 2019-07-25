using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetSpider.Statistics.Entity;

namespace DotnetSpider.Statistics.Store
{
    /// <summary>
    /// 统计存储接口
    /// </summary>
    public interface IStatisticsStore
    {
	    /// <summary>
	    /// 创建数据库和表
	    /// </summary>
	    /// <returns></returns>
	    Task EnsureDatabaseAndTableCreatedAsync();
	    
        /// <summary>
        /// 增加成功次数 1
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <returns></returns>
        Task IncrementSuccessAsync(string ownerId);

        /// <summary>
        /// 添加指定失败次数
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <param name="count">失败次数</param>
        /// <returns></returns>
        Task IncrementFailedAsync(string ownerId, int count = 1);

        /// <summary>
        /// 设置爬虫启动时间
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <returns></returns>
        Task StartAsync(string ownerId);
        
        /// <summary>
        /// 设置爬虫退出时间
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <returns></returns>
        Task ExitAsync(string ownerId);

        /// <summary>
        /// 添加指定下载代理器的下载成功次数
        /// </summary>
        /// <param name="agentId">下载代理器标识</param>
        /// <param name="count">下载成功次数</param>
        /// <param name="elapsedMilliseconds">下载总消耗的时间</param>
        /// <returns></returns>
        Task IncrementDownloadSuccessAsync(string agentId, int count, long elapsedMilliseconds);

        /// <summary>
        /// 添加指定下载代理器的下载失败次数
        /// </summary>
        /// <param name="agentId">下载代理器标识</param>
        /// <param name="count">下载失败次数</param>
        /// <param name="elapsedMilliseconds">下载总消耗的时间</param>
        /// <returns></returns>
        Task IncrementDownloadFailedAsync(string agentId, int count, long elapsedMilliseconds);

        /// <summary>
        /// 分页查询下载代理器的统计信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<List<DownloadStatistics>> GetDownloadStatisticsListAsync(int page, int size);

        /// <summary>
        /// 查询指定下载代理器的统计信息
        /// </summary>
        /// <param name="agentId">下载代理器标识</param>
        /// <returns></returns>
        Task<DownloadStatistics> GetDownloadStatisticsAsync(string agentId);

        /// <summary>
        /// 查询指定爬虫的统计信息
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <returns></returns>
        Task<SpiderStatistics> GetSpiderStatisticsAsync(string ownerId);

        /// <summary>
        /// 分页查询爬虫的统计信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<List<SpiderStatistics>> GetSpiderStatisticsListAsync(int page, int size);

        /// <summary>
        /// 添加总请求数
        /// </summary>
        /// <param name="ownerId">爬虫标识</param>
        /// <param name="count">请求数</param>
        /// <returns></returns>
        Task IncrementTotalAsync(string ownerId, int count);
    }
}