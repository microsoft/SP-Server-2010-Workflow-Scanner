﻿using OfficeDevPnP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery
{
    public class SiteScanResult : Scan
    {
        /// <summary>
        /// Web template (e.g. STS#0)
        /// </summary>
        public string WebTemplate { get; set; }

        /// <summary>
        /// Modern lists was disabled due to the site scoped blocking feature
        /// </summary>
        public bool ModernListSiteBlockingFeatureEnabled { get; set; }

        /// <summary>
        /// Does this site collection have sub sites?
        /// </summary>
        public bool SubSites { get; set; }

        /// <summary>
        /// Does this web have a modern home page?
        /// </summary>
        public bool ModernHomePage { get; set; }

        /// <summary>
        /// Is this the root site of the tenant
        /// </summary>
        public bool IsRootSite { get; set; }

        /// <summary>
        /// Does this site collection have sub sites with broken permission inheritance
        /// </summary>
        public bool SubSitesWithBrokenPermissionInheritance { get; set; }

        /// <summary>
        /// Is the publishing web feature enabled?
        /// </summary>
        public bool WebPublishingFeatureEnabled { get; set; }
        /// <summary>
        /// Does this site collection have the site pusblishing feature enabled?
        /// </summary>
        public bool SitePublishingFeatureEnabled { get; set; }

        /// <summary>
        /// Are there publishing pages used in any of the webs in this site?
        /// </summary>
        public bool PublishingPagesUsed { get; set; }
        /// <summary>
        /// Modern page feature was disabled
        /// </summary>
        public bool ModernPageWebFeatureDisabled { get; set; }

        /// <summary>
        /// Was the modern page feature enabled
        /// </summary>
        public bool ModernPageFeatureWasEnabledBySPO { get; set; }

        /// <summary>
        /// Modern lists was disabled due to the web scoped blocking feature
        /// </summary>
        public bool ModernListWebBlockingFeatureEnabled { get; set; }

        /// <summary>
        /// This site uses a non OOB master page
        /// </summary>
        public bool MasterPage { get; set; }

        /// <summary>
        /// This site uses alternate css
        /// </summary>
        public bool AlternateCSS { get; set; }

        /// <summary>
        /// User custom actions which are ignored on modern UI
        /// </summary>
        ///public List<UserCustomActionResult> SiteUserCustomActions { get; set; }

        /// <summary>
        /// User custom actions which are ignored on modern UI
        /// </summary>
        //public List<UserCustomActionResult> WebUserCustomActions { get; set; }

        /// <summary>
        /// Site administrators
        /// </summary>
        public List<UserEntity> Admins { get; set; }
        /// <summary>
        /// Site owners
        /// </summary>
        public List<UserEntity> Owners { get; set; }

        /// <summary>
        /// Site members
        /// </summary>
        public List<UserEntity> Members { get; set; }

        /// <summary>
        /// Site visitors
        /// </summary>
        public List<UserEntity> Visitors { get; set; }

        /// <summary>
        /// Is the everyone or every one except external users claim used to directly grant access
        /// </summary>
        public bool EveryoneClaimsGranted { get; set; }

        /// <summary>
        /// ID of the connected Office 365 group
        /// </summary>
        public Guid Office365GroupId { get; set; }

        /// <summary>
        /// Is there a Teams team connected to the same Office 365 group as this site collection
        /// </summary>
        public bool? HasTeamsTeam { get; set; }

        /// <summary>
        /// Site sharing capabilities
        /// </summary>
        public string SharingCapabilities { get; set; }

        /// <summary>
        /// Views in the last 14 days for this site
        /// </summary>
        public int ViewsRecent { get; set; }

        /// <summary>
        /// Number of unique users that viewed this site in the last 14 days
        /// </summary>
        public int ViewsRecentUniqueUsers { get; set; }

        /// <summary>
        /// Total number of views for this site
        /// </summary>
        public int ViewsLifeTime { get; set; }

        /// <summary>
        /// Total number of unique visitors for this site
        /// </summary>
        public int ViewsLifeTimeUniqueUsers { get; set; }

        /// <summary>
        /// Site collection ID
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Search center url for the site
        /// </summary>
        public string SearchCenterUrl { get; set; }

        #region Cloning
        /// <summary>
        /// Clone this object, keep in sync when new props are added to this class
        /// </summary>
        /// <returns></returns>
        public SiteScanResult Clone()
        {
            return new SiteScanResult()
            {
                SiteColUrl = this.SiteColUrl,
                SiteURL = this.SiteURL,
                ModernListSiteBlockingFeatureEnabled = this.ModernListSiteBlockingFeatureEnabled,
                ModernHomePage = this.ModernHomePage,
                IsRootSite = this.IsRootSite,
                SitePublishingFeatureEnabled = this.SitePublishingFeatureEnabled,
                WebPublishingFeatureEnabled = this.WebPublishingFeatureEnabled,
                PublishingPagesUsed = this.PublishingPagesUsed,
                ModernPageWebFeatureDisabled = this.ModernPageWebFeatureDisabled,
                ModernPageFeatureWasEnabledBySPO = this.ModernPageFeatureWasEnabledBySPO,
                ModernListWebBlockingFeatureEnabled = this.ModernListWebBlockingFeatureEnabled,
                WebTemplate = this.WebTemplate,
                SubSites = this.SubSites,
                SubSitesWithBrokenPermissionInheritance = this.SubSitesWithBrokenPermissionInheritance,
                MasterPage = this.MasterPage,
                //SiteUserCustomActions = this.SiteUserCustomActions,
                // WebUserCustomActions = this.WebUserCustomActions,
                AlternateCSS = this.AlternateCSS,
                Admins = this.Admins,
                Owners = this.Owners,
                Members = this.Members,
                Visitors = this.Visitors,
                EveryoneClaimsGranted = this.EveryoneClaimsGranted,
                Office365GroupId = this.Office365GroupId,
                HasTeamsTeam = this.HasTeamsTeam,
                SharingCapabilities = this.SharingCapabilities,
                ViewsLifeTime = this.ViewsLifeTime,
                ViewsLifeTimeUniqueUsers = this.ViewsLifeTimeUniqueUsers,
                ViewsRecent = this.ViewsRecent,
                ViewsRecentUniqueUsers = this.ViewsRecentUniqueUsers,
                SiteId = this.SiteId,
                SearchCenterUrl = this.SearchCenterUrl
            };
        }
        #endregion

        #region Groupify readiness
        /// <summary>
        /// Lists the reasons for not (yet) groupifying this site
        /// </summary>
        /// <returns>List of groupify blockers</returns>
        public List<string> GroupifyBlockers()
        {
            List<string> groupifyBlockReasons = new List<string>();

            // Don't use this as a blocker as it overlaps with the publishingFeature blocker and as such is confusing
            //var blocker = SiteTemplateCheck(true);
            //if (!String.IsNullOrEmpty(blocker))
            //{
            //    groupifyBlockReasons.Add(blocker);
            //}

            if (Office365GroupId != Guid.Empty)
            {
                groupifyBlockReasons.Add("SiteHasOffice365Group");
            }

            if ((SitePublishingFeatureEnabled || WebPublishingFeatureEnabled) && DefineAsPublishingPortal())
            {
                groupifyBlockReasons.Add("PublishingFeatureEnabled");
            }

            // We prevent a root site from being group connected
            if (IsRootSite)
            {
                groupifyBlockReasons.Add("IsTenantRootSite");
            }

            return groupifyBlockReasons;
        }

        /// <summary>
        /// Lists the reasons for not (yet) groupifying this site
        /// </summary>
        /// <returns>List of groupify warnings</returns>
        public List<string> GroupifyWarnings(string everyoneClaim, string everyoneExceptExternalUsersClaim)
        {
            List<string> groupifyWarningReasons = new List<string>();

            var permissionWarnings = this.PermissionModel(everyoneClaim, everyoneExceptExternalUsersClaim);
            if (permissionWarnings.Item2 != null && permissionWarnings.Item2.Count > 0)
            {
                groupifyWarningReasons.Add("PermissionWarnings");
            }

            if (SubSites)
            {
                groupifyWarningReasons.Add("SiteHasSubSites");
            }

            if (this.ModernWarnings().Count > 0)
            {
                groupifyWarningReasons.Add("ModernUIWarnings");
            }

            var warning = SiteTemplateCheck(false);
            if (!String.IsNullOrEmpty(warning))
            {
                groupifyWarningReasons.Add(warning);
            }

            return groupifyWarningReasons;
        }

        private bool DefineAsPublishingPortal()
        {
            // Check web template
            if (WebTemplate.Equals("BICENTERSITE#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("BLANKINTERNET#0", StringComparison.InvariantCultureIgnoreCase) ||
                WebTemplate.Equals("ENTERWIKI#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("SRCHCEN#0", StringComparison.InvariantCultureIgnoreCase) ||
                WebTemplate.Equals("SRCHCENTERLITE#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("POINTPUBLISHINGHUB#0", StringComparison.InvariantCultureIgnoreCase) ||
                WebTemplate.Equals("POINTPUBLISHINGTOPIC#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("CMSPUBLISHING#0", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            // Check publishing page library usage
            if (PublishingPagesUsed)
            {
                return true;
            }

            return false;
        }

        private string SiteTemplateCheck(bool blocker)
        {
            if (WebTemplate.Equals("STS#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("DEV#0", StringComparison.InvariantCultureIgnoreCase))
            {
                // We're good with these
                return null;
            }
            else if (WebTemplate.Equals("BICENTERSITE#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("BLANKINTERNET#0", StringComparison.InvariantCultureIgnoreCase) ||
                     WebTemplate.Equals("ENTERWIKI#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("SRCHCEN#0", StringComparison.InvariantCultureIgnoreCase) ||
                     WebTemplate.Equals("SRCHCENTERLITE#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("POINTPUBLISHINGHUB#0", StringComparison.InvariantCultureIgnoreCase) ||
                     WebTemplate.Equals("POINTPUBLISHINGTOPIC#0", StringComparison.InvariantCultureIgnoreCase) || WebTemplate.Equals("CMSPUBLISHING#0", StringComparison.InvariantCultureIgnoreCase) ||
                     SiteColUrl.EndsWith("/sites/contenttypehub", StringComparison.InvariantCultureIgnoreCase))
            {
                // Block these                
                if (blocker)
                {
                    return "IncompatibleWebTemplate";
                }
            }
            else
            {
                // Provide a warning
                if (!blocker)
                {
                    return "DefaultHomePageImpacted";
                }
            }

            return null;
        }

        /// <summary>
        /// Proposed permission model and permission delta for the created group
        /// </summary>
        /// <returns>PRIVATE or PUBLIC</returns>
        public Tuple<string, List<string>> PermissionModel(string claim1, string claim2)
        {
            // Do we have a public claim in Members, Owners or Admins? ==> PUBLIC site
            bool hasPublicClaimWithEditPermissions = HasClaim(Admins, claim1, claim2);
            if (!hasPublicClaimWithEditPermissions)
            {
                hasPublicClaimWithEditPermissions = HasClaim(Owners, claim1, claim2);
            }
            if (!hasPublicClaimWithEditPermissions)
            {
                hasPublicClaimWithEditPermissions = HasClaim(Members, claim1, claim2);
            }

            List<string> permissionDelta = new List<string>();
            // Potential issue 1: private group, but public claim has been used outside of Site Admins, Owners, Members
            //if (EveryoneClaimsGranted && !hasPublicClaimWithEditPermissions)
            //{
            //    permissionDelta.Add("PrivateGroupButEveryoneUsedOutsideOfAdminOwnerMemberGroups");
            //}

            //// Potential issue 2: public claim in visitors group will lead to private site while still allow everyone view access
            //if (HasClaim(Visitors, claim1, claim2) && !hasPublicClaim)
            //{
            //    permissionDelta.Add("PrivateGroupButEveryoneInVisitors");
            //}

            // Potential issue 3: external sharing disabled, but will be possible by default on groups
            if (!String.IsNullOrEmpty(SharingCapabilities))
            {
                if (SharingCapabilities.Equals("Disabled", StringComparison.InvariantCultureIgnoreCase))
                {
                    permissionDelta.Add("SharingDisabledForSiteButGroupWillAllowExternalSharing");
                }
            }

            // Potential issue 4: sub site has broken permission inheritance
            if (SubSitesWithBrokenPermissionInheritance)
            {
                permissionDelta.Add("SubSiteWithBrokenPermissionInheritance");
            }

            // Potential issue 5: ad groups used which will not expand into the Office 365 group
            if (ContainsADGroup(Owners) || ContainsADGroup(Admins) || ContainsADGroup(Members))
            {
                permissionDelta.Add("ADGroupWillNotBeExpanded");
            }

            return new Tuple<string, List<string>>(hasPublicClaimWithEditPermissions ? "PUBLIC" : "PRIVATE", permissionDelta);
        }

        /// <summary>
        /// Lists the modern UI disablements
        /// </summary>
        /// <returns>List of modern UI disablements</returns>
        public List<string> ModernWarnings()
        {
            List<string> modernWarnings = new List<string>();

            if (ModernPageWebFeatureDisabled)
            {
                modernWarnings.Add("ModernPageFeatureDisabled");
            }
            if (ModernListSiteBlockingFeatureEnabled)
            {
                modernWarnings.Add("ModernListsBlockedAtSiteLevel");
            }
            if (ModernListWebBlockingFeatureEnabled)
            {
                modernWarnings.Add("ModernListsBlockedAtWebLevel");
            }
            if (MasterPage)
            {
                modernWarnings.Add("MasterPageUsed");
            }
            if (AlternateCSS)
            {
                modernWarnings.Add("AlternateCSSUsed");
            }
            /*if ((SiteUserCustomActions != null && SiteUserCustomActions.Count > 0) || (WebUserCustomActions != null && WebUserCustomActions.Count > 0))
            {
                modernWarnings.Add("UserCustomActionUsed");
            }*/
            if (SitePublishingFeatureEnabled || WebPublishingFeatureEnabled)
            {
                modernWarnings.Add("PublishingFeatureEnabled");
            }

            return modernWarnings;
        }

        #endregion

        #region Security helpers
        /// <summary>
        /// Does the given user list contain the given claim
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="claim">Claim to check</param>
        /// <returns>True if found, false otherwise</returns>
        public bool HasClaim(List<UserEntity> users, string claim)
        {
            if (users == null)
            {
                return false;
            }

            return users.Where(p => p.LoginName.ToLower() == claim.ToLower()).Any();
        }

        /// <summary>
        /// Does the given user list contain any of the 2 given claims
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="claim1">Claim to check</param>
        /// <param name="claim2">Claim to check</param>
        /// <returns>True if found, false otherwise</returns>
        public bool HasClaim(List<UserEntity> users, string claim1, string claim2)
        {
            if (users == null)
            {
                return false;
            }

            return users.Where(p => p.LoginName.ToLower() == claim1.ToLower() || p.LoginName.ToLower() == claim2.ToLower()).Any();
        }

        /// <summary>
        /// Is the given claim used for this site?
        /// </summary>
        /// <param name="claim">Claim to check</param>
        /// <returns>True if found, false otherwise</returns>
        public bool HasClaim(string claim)
        {
            if (HasClaim(Admins, claim))
            {
                return true;
            }
            if (HasClaim(Owners, claim))
            {
                return true;
            }
            if (HasClaim(Members, claim))
            {
                return true;
            }
            if (HasClaim(Visitors, claim))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Is one of the given claims used for this site?
        /// </summary>
        /// <param name="claim1">Claim to check</param>
        /// <param name="claim2">Claim to check</param>
        /// <returns>True if found, false otherwise</returns>
        public bool HasClaim(string claim1, string claim2)
        {
            if (HasClaim(Admins, claim1, claim2))
            {
                return true;
            }
            if (HasClaim(Owners, claim1, claim2))
            {
                return true;
            }
            if (HasClaim(Members, claim1, claim2))
            {
                return true;
            }
            if (HasClaim(Visitors, claim1, claim2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Does this user list contain a AD group?
        /// </summary>
        /// <param name="users">List of users</param>
        /// <returns>True if it contains an AD group, false otherwise</returns>
        public bool ContainsADGroup(List<UserEntity> users)
        {
            if (users == null)
            {
                return false;
            }

            return users.Where(p => p.LoginName.ToLower().StartsWith("c:0-.f|rolemanager|s-")).Any();
        }

        /// <summary>
        /// Does this site use AD groups to grant permissions
        /// </summary>
        /// <returns>True or false</returns>
        public bool ContainsADGroup()
        {
            if (ContainsADGroup(Admins))
            {
                return true;
            }
            if (ContainsADGroup(Owners))
            {
                return true;
            }
            if (ContainsADGroup(Members))
            {
                return true;
            }
            if (ContainsADGroup(Visitors))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region output formatting
        public string IsTeamified()
        {
            if (this.HasTeamsTeam.HasValue)
            {
                if (this.HasTeamsTeam.Value)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            else
            {
                return "";
            }
        }

        public static string FormatUserList(List<UserEntity> users, string everyoneClaim = null, string everyoneExceptExternalUsersClaim = null)
        {
            string userList = "";

            // Bail out if we've no data
            if (users == null || users.Count == 0)
            {
                return userList;
            }

            foreach (var user in users)
            {
                string userToAdd = (!string.IsNullOrEmpty(user.Email) && user.Email.Contains("@")) ? user.Email : user.LoginName;

                if (!userToAdd.Equals("SHAREPOINT\\system", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!string.IsNullOrEmpty(everyoneClaim) && userToAdd.Equals(everyoneClaim, StringComparison.InvariantCultureIgnoreCase))
                    {
                        userToAdd = "{everyone}";
                    }
                    else if (!string.IsNullOrEmpty(everyoneExceptExternalUsersClaim) && userToAdd.Equals(everyoneExceptExternalUsersClaim, StringComparison.InvariantCultureIgnoreCase))
                    {
                        userToAdd = "{everyoneexceptexternalusers}";
                    }

                    userList = userList + (!string.IsNullOrEmpty(userList) ? $",{userToAdd}" : $"{userToAdd}");
                }
            }
            return userList;
        }

        public static string FormatList(List<string> list)
        {
            string formattedList = "";
            if (list == null || list.Count == 0)
            {
                return "";
            }

            foreach (var item in list)
            {
                formattedList = formattedList + (!string.IsNullOrEmpty(formattedList) ? $",{item}" : $"{item}");
            }

            return formattedList;
        }

        #endregion

    }
}
