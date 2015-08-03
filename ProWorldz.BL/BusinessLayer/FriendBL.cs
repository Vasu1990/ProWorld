using ProWorldz.BL.BusinessModel;
using ProWorldz.BL.Common.DatatablePaging;
using ProWorldz.BL.Common.Enums;
using ProWorldz.DL;
using ProWorldz.DL.Models;
using ProWorldz.DL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProWorldz.BL.BusinessLayer
{
    public class FriendBL
    {
        UnitOfWork uow;
        int CurrentUser = 0;
        public FriendBL()
        {
            uow = new UnitOfWork();
        }

        public void Create(FriendBM model)
        {
            uow.FriendRepository.Add(ConvertToDM(model));
            uow.Save();
        }
        public List<FriendBM> GetFriend()
        {
            return uow.FriendRepository.GetAll().ConvertAll<FriendBM>(new Converter<Friend, FriendBM>(ConvertToBM));
        }

        public int GetFriendCountById(int CurrentUserId)
        {
            ProWorldzContext context = new ProWorldzContext();
            int count = (from frnd in context.Friend
                         where frnd.UserId == CurrentUserId
                         && frnd.FriendShipStatusId == (int)FriendShipStatus.Accepted
                         select new { }).Count();
            return count;
        }
        public int GetUserCountByName(string name)
        {
            UserBL user = new UserBL();
            return user.GetUserCountByName(name);
        }

        public void CreateFriendrequest(List<FriendBM> frndbm) 
        {
            ProWorldzContext context = new ProWorldzContext();
            List<Friend> friends = frndbm.ConvertAll<Friend>(new Converter<FriendBM, Friend>(ConvertToDM));
            context.Friend.AddRange(friends);
            context.SaveChanges();
        }
        public void DeleteFriend(FriendBM frndbm)
        {
            List<Friend> frndList = uow.FriendRepository.Find(x => x.UserId == frndbm.UserId && x.FriendId == frndbm.FriendId || x.UserId == frndbm.FriendId && x.FriendId == frndbm.UserId);

            foreach (var item in frndList)
            {
                uow.FriendRepository.Delete(item);
                uow.Save();
            }
        }
        public void ConfirmFriendRequest(FriendBM frndbm)
        {

            ProWorldzContext context = new ProWorldzContext();
            List<Friend> frndList = uow.FriendRepository.Find(x => x.UserId == frndbm.UserId && x.FriendId == frndbm.FriendId || x.UserId == frndbm.FriendId && x.FriendId == frndbm.UserId );

            foreach (var item in frndList)
            {
                item.FriendShipStatusId = (int)FriendShipStatus.Accepted;
                uow.FriendRepository.Update(item);
                uow.Save();
            }
        }

        private FriendBM ConvertToDM(Friend input)
        {
            throw new NotImplementedException();
        }
      

        public List<FriendBM> GetFriendListById(int CurrentUserId, DataTableParams param)
        {
            ProWorldzContext context = new ProWorldzContext();

            //Join User & Frien table to find current users frient with Accepted status
            //Join with GeneralInfo to get users Image
            //IQueryable<FriendBM> frndCollection =

            //   (from frnd in context.Friend
            //    join curUser in context.Users on
            //    frnd.UserId equals curUser.Id
            //    join genInfo in context.UserGeneralInfomation on
            //    frnd.FriendId equals genInfo.UserId
            //    into t
            //    from rt in t.DefaultIfEmpty()
            //    where frnd.FriendShipStatusId == (int)FriendShipStatus.Accepted && curUser.Id == CurrentUserId
            //    select new FriendBM
            //    {
            //        FriendName = curUser.Name,
            //        FriendCommunity = curUser.CommunityName,
            //        FriendImage = rt.Image != "" ? rt.Image : "",
            //        Id = frnd.Id,
            //        FriendId = frnd.FriendId,
            //        UserId = curUser.Id
            //    });

            var b = from user in context.Users
                    join fr in context.Friend
                    on user.Id equals fr.UserId
                    where user.Id == CurrentUserId && fr.FriendShipStatusId == (int)FriendShipStatus.Accepted
                    select new { fr.FriendId, fr.UserId };

            IQueryable<FriendBM> frndCollection = from curUser in context.Users
                                                  join genInfo in context.UserGeneralInfomation
                                                  on curUser.Id equals genInfo.UserId 
                                                  into t
                                                  from rt in t.DefaultIfEmpty()
                                                  where b.Any(o => o.FriendId == curUser.Id)
                                                  select new FriendBM
                                                  {
                                                      FriendName = curUser.Name,
                                                      FriendCommunity = curUser.CommunityName,
                                                      FriendImage = rt.Image !=null ? rt.Image : "",
                                                      FriendId = curUser.Id,
                                                      UserId = b.Where(x => x.FriendId == curUser.Id).Select(x => x.UserId).FirstOrDefault()
                                                  };

            //Pagination logic Math.Min returns the least from both values
            int RecordsToFetch = Math.Min(frndCollection.Count() - param.RecordsToSkip, param.RecordsToTake);
            frndCollection = frndCollection.OrderBy(x => x.FriendName).Skip(param.RecordsToSkip).Take(RecordsToFetch);

            //Searching
            if (param.SearchOptions.value != null)
            {
                frndCollection = frndCollection.Where(x => x.FriendName.Contains(param.SearchOptions.value));
            }


            return frndCollection.ToList();


            //***Problem with lambda it fills the FriendUser Model with Current User info not with Friend's Info***//

            //IQueryable<Friend> frndCollection = context.Friend.Where(x => x.UserId == CurrentUserId
            //    && x.FriendShipStatusId == (int)FriendShipStatus.Accepted).
            //    OrderBy(x => x.FriendUser.Name);
            //int RecordsToFetch = Math.Min(frndCollection.Count() - param.RecordsToSkip, param.RecordsToTake);
            //frndCollection = frndCollection.Skip(RecordsToFetch).Take(param.RecordsToSkip);
            // List<FriendBM> frndBM = frndCollection.ToList().ConvertAll<FriendBM>(new Converter<Friend, FriendBM>(ConvertToBM));
        }

        public List<FriendBM> GetUsersWithFriendStatus(string SearchString, int UserId, DataTableParams param)
        {
            UserBL userObj = new UserBL();
            CurrentUser = UserId;

            List<UserBM> Users = userObj.GeteUserByName(SearchString,param).Where(x=>x.Id != UserId).ToList();
            return Users.ConvertAll<FriendBM>(new Converter<UserBM, FriendBM>(ConvertToFriendBM));

        }

        private FriendBM ConvertToFriendBM(UserBM model)
        {

            FriendBM frnd = new FriendBM();

            frnd.UserId = CurrentUser;
            frnd.FriendName = model.Name;
            frnd.FriendCommunity = model.CommunityName;
            //     frnd.FriendImage = model.GeneralInfo.Image!=null?model.GeneralInfo.Image:"";

            var friend = uow.FriendRepository.Find(x => x.UserId == CurrentUser && x.FriendId == model.Id).FirstOrDefault();
            if (friend == null)
            {
                frnd.FriendId = model.Id;
                frnd.FriendShipStatusId = 0;
            }
            else
            {
                frnd.Id = friend.Id;
                frnd.FriendShipStatusId = friend.FriendShipStatusId;
                frnd.FriendId = friend.FriendId;
                frnd.CreationDate = friend.CreationDate;
            }
            return frnd;
        }

        public FriendBM GetFriendById(int id)
        {
            return ConvertToBM(uow.FriendRepository.GetByID(id));
        }


        public void Update(FriendBM model)
        {
            uow.FriendRepository.Update(ConvertToDM(model));
            uow.Save();
        }

        private Friend ConvertToDM(FriendBM model)
        {
            return new Friend
            {
                CreationDate = model.CreationDate,
                FriendShipStatusId = model.FriendShipStatusId,
                FriendId = model.FriendId,
                UserId = model.UserId

            };
        }

        private FriendBM ConvertToBM(Friend model)
        {
            return new FriendBM()
            {
                CreationDate = model.CreationDate,
                FriendShipStatusId = model.FriendShipStatusId,
                FriendId = model.FriendId,
                UserId = model.UserId,
                FriendName = model.FriendUser.Name,
                FriendImage = model.FriendUser.UserGeneralInfo.Where(x => x.UserId == model.FriendId).Select(x => x.Image).FirstOrDefault(),
                FriendCommunity = model.FriendUser.CommunityName,

            };
        }
        public void Delete(FriendBM model)
        {
            uow.FriendRepository.Delete(ConvertToDM(model));
            uow.Save();
        }

        public List<FriendBM> GetNewFriends(int CurrentUserId)
        {
            ProWorldzContext context = new ProWorldzContext();
               var b = from user in context.Users
                    join fr in context.Friend
                    on user.Id equals fr.UserId
                    where user.Id == CurrentUserId && fr.FriendShipStatusId == (int)FriendShipStatus.New
                    select new { fr.FriendId, fr.UserId };

            IQueryable<FriendBM> frndCollection = from curUser in context.Users
                                                  join genInfo in context.UserGeneralInfomation
                                                  on curUser.Id equals genInfo.UserId 
                                                  into t
                                                  from rt in t.DefaultIfEmpty()
                                                  where b.Any(o => o.FriendId == curUser.Id)
                                                  select new FriendBM
                                                  {
                                                      FriendName = curUser.Name,
                                                      FriendCommunity = curUser.CommunityName,
                                                      FriendImage = rt.Image !=null ? rt.Image : "",
                                                      FriendId = curUser.Id,
                                                      UserId = b.Where(x => x.FriendId == curUser.Id).Select(x => x.UserId).FirstOrDefault()
                                                  };
            return frndCollection.ToList();
        }
    }
}
