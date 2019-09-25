const session = new Vue({
    el: '#login',
    data: {
        Login: '',
        Pass: ''
    },
    mounted() {
        if (localStorage.name) {
            this.Login = localStorage.name;
        }
    },
    watch: {
        name(newName) {
            localStorage.name = newName;
        }
    }
});
