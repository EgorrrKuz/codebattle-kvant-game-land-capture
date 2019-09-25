<template>
  <div >
    <h1>Login</h1><br>
    <form action="/post" v-if="!loading">
      <v-layout column align-center>
        <input v-model="username" type="password" placeholder="Enter login">
        <input v-model="password" type="password" placeholder="Enter password">
        <input type="submit" v-on:click.prevent="login">
      </v-layout>
    </form>
    <Loading v-if="loading"></Loading>
  </div>
</template>
<script>
import Loading from "./Loading.vue";
export default {
  name: "login",
  components: { Loading },
  data() {
    return {
      loading: false,
      username: "",
      password: ""
    };
  },
  methods: {
    login: () => {
      // should be replaced by real login code
      // there I just did some simple validation and use a fake login
      if (this.username !== "" && this.password !== "") {
        // show the loading message
        this.loading = true;
        setTimeout(() => {
          this.loading = false;

          // use vuex to store user inforamtion
          this.$store.dispatch("update_user_name", this.username);

          // save login status in localstorage
          localStorage.setItem("login", true);

          // redirect to user page
          this.$router.push("/user");
        }, 1000);
      }
    }
  }
};
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
