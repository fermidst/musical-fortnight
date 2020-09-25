<template>
  <div>
    <el-row type="flex" justify="center">
      <el-col :sm="14" :md="6" :lg="4" :xl="4" :xs="16">
        <el-input
          placeholder="Enter message to encrypt"
          v-model="message"
        ></el-input>
      </el-col>
    </el-row>

    <el-row>
      <el-col>
        <el-button @click="encryptMessage">Encrypt</el-button>
      </el-col>
    </el-row>

    <el-table :data="encryptedMessages">
      <el-table-column
        align="center"
        prop="encryptedMessage"
        label="Encrypted Message"
      ></el-table-column>
    </el-table>
  </div>
</template>

<script>
import Axios from "axios";

export default {
  name: "EncryptMessage",
  data() {
    return {
      message: null,
      encryptedMessages: []
    };
  },
  methods: {
    encryptMessage() {
      Axios.post("https://localhost:44348/message/encrypt", {
        message: this.message
      }).then(response => {
        this.encryptedMessages.push(response.data);
      });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.el-button {
  margin: 12px;
}
</style>
