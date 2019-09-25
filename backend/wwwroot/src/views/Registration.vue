<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column align-center id="register">
        <h1>Registarion</h1><br>
        <input v-model="Login" placeholder="Enter email">
        <input v-model="Pass" type="password" placeholder="Enter password">
        <input v-model="ConfirmPass" type="password" placeholder="Confirm password">
        <input type="submit" v-on:click.prevent="reg()">
        <br><h2>{{Message}}</h2>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
// import Reg from "@/Controllers/playerController";
export default class RegistrationView extends Vue {}
</script>
