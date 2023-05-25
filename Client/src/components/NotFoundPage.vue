<template>
   <span style="margin-top:20%;font-size:60px;color:black" class="d-flex justify-content-center" font-weight:bold>404: Page Not Found</span>
</template>


<script  lang="ts">
export default {
  name: 'NotFoundPage',
  props: {
    msg: String
  }
}
</script>


<style scoped>
h3 {
  margin: 40px 0 0;
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
