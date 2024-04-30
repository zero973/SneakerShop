export default class AppUser {

    constructor(Id, Login, Roles) {
        this.Id = Id;
        this.Login = Login;
        this.Roles = Roles;
    }

    isAuthorized() {
        return this.Id != undefined;
    }

    isInRole(roleName) {
        return this.Roles.includes(roleName);
    }

}