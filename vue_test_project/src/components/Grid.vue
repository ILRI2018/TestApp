<template>
<div class="container">
    <table class="table mt-5">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Год</th>
      <th scope="col">Количество метеоритов</th>
      <th scope="col">Суммарная масса</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>1980</td>
      <td>12</td>
      <td>100</td>
    </tr>
    <tr>
      <th scope="row">2</th>
      <td>1981</td>
      <td>4</td>
      <td>200</td>
    </tr>
  </tbody>
  <tfoot>
    <tr class="table-info">
      <td> </td>
      <td>Total</td>
      <td>16</td>
      <td>300</td>
    </tr>
  </tfoot>
</table>
</div>
  

</template>

<script>
export default {
  name: 'GridModule',
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
