<template>
<div class="container">
  <div class="main-block">
    <div class="col-md-3 main-block-item">
      <select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example">
      <option selected></option>
      <option value="1">One</option>
      <option value="2">Two</option>
      <option value="3">Three</option>
    </select>
    </div>
    <div class="col-md-3 main-block-item">
      <select class="form-select form-select-lg mb-3" aria-label=".form-select-lg example">
      <option selected></option>
      <option value="1">One</option>
      <option value="2">Two</option>
      <option value="3">Three</option>
    </select>
    </div>
    <div class="col-md-3 main-block-item">
      <div class="mb-3">
        <input type="email" class="form-control block-item-input" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Название метеорита">
      </div>
    </div>
    <div class="col-md-3">
      <button type="button" class="btn btn-primary btn-lg">Применить</button>
    </div>
  </div>
</div>
  

</template>

<script>
export default {
  name: 'FilterModule',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

.main-block-item {
  margin-left: 20px;
}

.main-block {
  display: flex;
  justify-content: flex-start;
}

.block-item-input {
  height: 48px;
}

.btn-group {
  margin-left: 20px;
}

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
