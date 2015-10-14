(function (jobVM) {
    console.log(jobVM);
    jobVM.JobPost = function (data) {
        debugger;
        
        //proWorld.AjaxHelper.AjaxPostCallNoType("/Area/Employer/Job/PostJob", data, OnSuccessJobPost);

        var _jobObj = {
            Headline: data.Job.Headline,
            Designation: data.Job.Designation,
            JobRole: data.JobRole,
            JobSkill: data.JobSkill,
            JobFunction: data.JobFunction,
            CountryId: data.CountryId,
            StateId: data.StateId,
            CityId: data.CityId,
            CommunityId: data.CommunityId,
            SubCommunityId: data.SubCommunityId,
            EducationQualification: data.EducationQualification,
            ExpYear: data.ExpYear,
            ExpMonth: data.ExpMonth,
            IndustryId: data.IndustryId,
            SalaryLakhs: data.SalaryLakhs,
            SalaryThousands: data.SalaryThousands,
            JobDescription: data.JobDescription,
            PostingDate: data.PostingDate,
            DateOfAdvExp: data.DateOfAdvExp,
            Email: data.Email,
            ContactPerson: data.ContactPerson,
            EmployementType: data.EmployementType

            
        }
        //cast ko model to json and post request
        var _jobBM = ko.toJS(_jobObj)
        proWorld.AjaxHelper.AjaxPostCallNoType("/Employer/Job/PostJob", _jobBM, OnSuccessJobPost);
        //$.ajax({
        //    type: "POST",
        //    url: '/Employer/Job/PostJob',
        //    data: _jobBM,
        //    success: OnSuccessJobPost,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //});
        
        function OnSuccessJobPost(){
            alert("success")
        }
    }
   
    ko.applyBindings(jobVM, $("#dvJobPost")[0]);
})(JobPostVM);